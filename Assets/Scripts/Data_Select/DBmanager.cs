using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;

public class DBmanager : MonoBehaviour {

    string rutaDB;
    string conexion;
    
    IDbConnection conexionDB;
    IDbCommand comandosDB;
    IDataReader leerDatos;

    string nombreDB = "UserLogRoRo.sqlite";

    private void Start()
    {
        AbrirDB();



        ComandoSelect("*", "Names");


        CerrarDB();
    }

    void AbrirDB() //DETALLE DEL COMANDO
    {
        rutaDB = Application.dataPath + "/StreamingAssets/" + nombreDB; //VARIABLE RUTA
        conexion = "URI=file:" + rutaDB; //ESPECIFICAR A LA BASE
        conexionDB = new SqliteConnection(conexion); //COMANDO SQL PARA ABRIR
        conexionDB.Open(); //APERTURA DE LA BASE EN EL SCRIPT 
    }

    void CerrarDB()
    {
        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }

    public bool ItemVerifier(string Name, string Item)
    {

        return true;
    }

    void ComandoSelect(string item, string tabla) //COMANDO MAS LAS VARIABLES
    {
        comandosDB = conexionDB.CreateCommand(); //ASIGNAR NUEVO COMANDO A LA VARIABLE
        string sqlQuery = "select " + item + " from " + tabla; //ESTRIUCTURA DEL COMANDO SQL
        comandosDB.CommandText = sqlQuery; //COMANDO DE SQL
        leerDatos = comandosDB.ExecuteReader(); //VERIABLE PARA TRABAJO DE LECTURA
        while (leerDatos.Read()) //CONDICION
        {
            try
            {
                Debug.Log(leerDatos.GetInt32(0) + " - " + leerDatos.GetString(1) + " - " + leerDatos.GetInt32(2));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }

    void ComandoWHERE(string item, string tabla, string campo, string comparador, string dato)
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select " + item + " from " + tabla + " where " + campo + " " + comparador + " " + dato;
        comandosDB.CommandText = sqlQuery;
        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            try
            {
                Debug.Log(leerDatos.GetInt32(0) + " - " + leerDatos.GetString(1) + " - " + leerDatos.GetInt32(2));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }

    void ComandoWHERE_AND(string item1, string item2, string item3, string item4,
                            string tabla,
                            string campo1, string comparador1, string dato1,
                            string campo2, string comparador2, string dato2)
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select " + item1 + "," + item2 + "," + item3 + "," + item4 +
                          " from " + tabla +
                          " where " + campo1 + " " + comparador1 + " " + "'" + dato1 + "'" +
                          " and " + campo2 + " " + comparador2 + dato2;
        comandosDB.CommandText = sqlQuery;
        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            try
            {
                Debug.Log(leerDatos.GetInt32(0) + " - " +
                    leerDatos.GetString(1) + " - " +
                            leerDatos.GetString(2) + " - " +
                            leerDatos.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }

    void ComandoWHERE_AND_ORDER_BY(string item1, string item2, string item3, string item4,
                            string tabla,
                            string campo1, string comparador1, string dato1,
                            string campo2, string comparador2, string dato2,
                            string campo3, string orden)
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select " + item1 + "," + item2 + "," + item3 + "," + item4 +
                          " from " + tabla +
                          " where " + campo1 + " " + comparador1 + " " + "'" + dato1 + "'" +
                          " and " + campo2 + " " + comparador2 + dato2 +
                          " order by " + campo3 + " " + orden;
        comandosDB.CommandText = sqlQuery;
        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            try
            {
                Debug.Log(leerDatos.GetInt32(0) + " - " +
                            leerDatos.GetString(1) + " - " +
                            leerDatos.GetString(2) + " - " +
                            leerDatos.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }

    void ComandoIN(string item1, string item2, string item3, string item4,
                            string tabla,
                            string campo1, string dato1, string dato2)
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select " + item1 + "," + item2 + "," + item3 + "," + item4 +
                          " from " + tabla +
                          " where " + campo1 + " " + "IN" + " " + "('" + dato1 + "'" + ",'" + dato2 + "')";

        comandosDB.CommandText = sqlQuery;
        leerDatos = comandosDB.ExecuteReader();
        while (leerDatos.Read())
        {
            try
            {
                Debug.Log(leerDatos.GetInt32(0) + " - " +
                            leerDatos.GetString(1) + " - " +
                            leerDatos.GetString(2) + " - " +
                            leerDatos.GetString(3));
            }
            catch (FormatException fe)
            {
                Debug.Log(fe.Message);
                continue;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                continue;
            }
        }
    }

    void FuncCOUNT()
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "SELECT count(*) FROM customers where Country = \"Canada\"";
        comandosDB.CommandText = sqlQuery;
        int FilaCont = 0;
        FilaCont = Convert.ToInt32(comandosDB.ExecuteScalar());
        Debug.Log(FilaCont);
        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }

    void FuncAVG()
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "select avg (total) from invoices";
        comandosDB.CommandText = sqlQuery;
        Double FilaCont = 0;
        FilaCont = Convert.ToDouble(comandosDB.ExecuteScalar());
        Debug.Log(FilaCont);
        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }

    public void INSERT(string dato)
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = String.Format("insert into media_types(Name) values(\"{0}\")", dato);
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();

        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }

    void DELETE()
    {
        comandosDB = conexionDB.CreateCommand();
        string sqlQuery = "delete from media_types where MediaTypeId = 11";
        comandosDB.CommandText = sqlQuery;
        comandosDB.ExecuteScalar();

        comandosDB.Dispose();
        comandosDB = null;
        conexionDB.Close();
        conexionDB = null;
    }
}
