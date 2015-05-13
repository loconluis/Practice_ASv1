using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace pracipc2_v2
{
    public class conexion
    {
        //Establecer la conexion
        private SqlConnection cnn;

        public conexion()
        {

            cnn = new SqlConnection("Data Source=LUISLOCON-PC;Initial Catalog=PRAIPC;Integrated Security=True");

        }

        public SqlConnection getConexion
        {
            get
            {
                return cnn;
            }

        }


    }
}