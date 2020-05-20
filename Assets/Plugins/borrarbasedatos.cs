using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class borrarbasedatos : MonoBehaviour
{
    public GameObject botonborrar;
    public GameObject botonempezar;

    public GameObject Input;

    public Text nombres;

    private string paciente;



    private void Start()
    {
        
    }

    public void sqlite()
    {
        botonborrar.SetActive(false);
        botonempezar.SetActive(false);
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "DELETE FROM informacion WHERE cedula =" + Input.GetComponent<Text>().text; 
        Debug.Log("log " + sqlQuery);

        nombres.text = "Usuario Eliminado";

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

}

