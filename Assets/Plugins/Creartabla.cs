using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Creartabla : MonoBehaviour
{

    IDbCommand dbcmd;
    IDataReader reader;
    //public GameObject Input1;
    public Text cedula;
    public Button boton;
    public void Start()
    {
        cedula.text = info.cedula;
        boton.gameObject.SetActive(true);
        
    }

    public void sqlite()
    {
        if (info.tabla == 1)
        {

            string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            string q_createTable = "CREATE TABLE IF NOT EXISTS CI_" + info.cedula + "  (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Nombres TEXT NOT NULL, cedula TEXT NOT NULL, Ejercicio TEXT NOT NULL, Nivel INTEGER NOT NULL, Tiempo REAL NOT NULL, errores REAL NOT NULL, Peso TEXT NOT NULL, Fecha TEXT NOT NULL, Hora TEXT NOT NULL, Trayectoria TEXT NOT NULL)";
            // string q_createTable = "CREATE TABLE IF NOT EXISTS CI_1719259762  (id    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,Nombres   TEXT NOT NULL,cedula    TEXT NOT NULL,edad  INTEGER NOT NULL,patologia TEXT NOT NULL)";
            Debug.Log(info.cedula);
            Debug.Log("tabla creada");
            dbcmd.CommandText = q_createTable;
            reader = dbcmd.ExecuteReader();




            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

        }

    }

}




