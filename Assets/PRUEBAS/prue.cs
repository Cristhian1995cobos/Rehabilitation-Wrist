using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;


public class prue : MonoBehaviour
{

    public Dropdown lista;
    public Dropdown lista2;
    public GameObject text1;
    List<string> listass = new List<string>();
    List<string> listas2 = new List<string>();
    int cedula;

    void Start()
    {
        lista.ClearOptions();
        lista2.ClearOptions();
        sqlite();
        lista.AddOptions(listass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void botonlista()
    {

        string nombres = text1.GetComponent<Text>().text;
        Debug.Log(nombres);
     




            string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT cedula FROM Informacion WHERE Nombres=" + "'" + nombres + "'"; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
            Debug.Log("log" + sqlQuery);

            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                cedula = reader.GetInt32(0);
            }
            Debug.Log(cedula);
            lista2.ClearOptions();
            sqlitd();
            lista2.AddOptions(listas2);
        
    }
public void sqlitd()
    {
  
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Fecha FROM CI_"+cedula+" WHERE Ejercicio='TALADRO' AND Nivel=1"; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string fechas = reader.GetString(0);
            listas2.Add(fechas);
        }
        

    }
    public void sqlite()
    {

        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Nombres FROM Informacion"; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string nombre = reader.GetString(0);
            listass.Add(nombre);
        }

    }

}
