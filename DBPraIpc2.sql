CREATE DATABASE PRAIPC

USE PRAIPC

CREATE TABLE CARRERA(
id_carrera int not null, 
nombre_carr varchar(40) not null
)

CREATE TABLE ESTUDIANTE(
carnet numeric not null, 
nombre varchar(25),
apellido varchar(25),
nota decimal(4,0),
id_carrera int not null
)

ALTER TABLE ESTUDIANTE ADD FOREIGN KEY (id_carrera) REFERENCES CARRERA(id_carrera)