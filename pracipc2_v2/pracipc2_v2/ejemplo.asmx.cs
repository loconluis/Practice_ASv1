using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace pracipc2_v2
{
    /// <summary>
    /// Descripción breve de ejemplo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ejemplo : System.Web.Services.WebService
    {
        conexion cnn = new conexion();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<String> RetornarDatos(int carnet) {
            string carne, nombre, apellido, nota, carrera = "";

            string consulta = "SELECT nombre, apellido, nota, nombre_carr FROM ESTUDIANTE E INNER JOIN CARRERA C ON E.id_carrera = C.id_carrera where carnet="+carnet;
            SqlCommand comm = new SqlCommand(consulta, cnn.getConexion);
            DataSet ds;
            ds = new DataSet();
            SqlDataAdapter datos = new SqlDataAdapter(comm);
            DataTable tabla = new DataTable("Datos");
            datos.Fill(tabla);
            List<string> capsula = new List<string>();


            try
            {
                cnn.getConexion.Open();
                SqlDataReader leer = comm.ExecuteReader();

                if (leer.Read() == true)
                {
                    carne = carnet.ToString();
                    nombre = leer[0].ToString();
                    apellido = leer[1].ToString();
                    nota = leer[2].ToString();
                    carrera = leer[3].ToString();

                    capsula.Add(carne);
                    capsula.Add(nombre);
                    capsula.Add(apellido);
                    capsula.Add(nota);
                    capsula.Add(carrera);

                    //return "El estudiante con carnet: " + carne + " y Nombre Completo: " + nombre + " " + apellido + " con nota: " + nota + "y carrera: " + carrera + "";
                    return capsula;
                    //bt_Add.Enabled = false;
                }

                else
                {
                    return null;
                    //clean();
                }
                
                //cnn.getConexion.Close();
            }
            catch
            {
                return null;
            }


            //try
            //{
            //    cnn.getConexion.Open();
            //    comm.ExecuteNonQuery();
            //    cnn.getConexion.Close();
            //    return "Econtrado";
            //}
            //catch
            //{
            //    return "No Encontrado";
            //}

            
        }

    }
}
