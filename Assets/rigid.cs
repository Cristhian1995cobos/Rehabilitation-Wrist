using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System;

public class rigid : MonoBehaviour
{
    public GameObject texto;
    public Text titulo;
    private string respuestaBase;
    private string respuestaBase2;

    // Use this for initialization
    void Start()
    {

        sqlite();
        texto.GetComponent<Text>().text = respuestaBase;
        titulo.text = respuestaBase2;
        Instantiate(texto, new Vector3(0, 0, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void sqlite()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM informacion"; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        respuestaBase2 = "Id\t\tNombres\t\t\t Cédula\t   Edad\tPatología\t\t Fecha\t\t  Hora\n_________________________________________________________________________________\n";

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nombre = reader.GetString(1);
            Int64 cedula = reader.GetInt64(2);
            int edad = reader.GetInt32(3);
            string patologia = reader.GetString(4);
            string fecha = reader.GetString(5);
            string hora = reader.GetString(6);


            respuestaBase +="" + limitStr(id+"",3) + "\t" + limitStr(nombre,18)+" "  + limitStL(cedula+"",10) +"   " + limitStr(edad+"",3) + "\t" + limitStr(patologia,15) + "\t" + limitStr(fecha,10) + "\t" + limitStr(hora,8) + "\n";

            

        }
        Debug.Log(respuestaBase);



        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    public string limitStr(string cadena, int n)
    {

        if (cadena.Length > n)
        {
            return cadena.Substring(0, n);
        }
        else
        {
            return cadena.PadRight(n,' ');
        }
        

    }
    public string limitStL(string cadena, int n)
    {

        if (cadena.Length > n)
        {
            return cadena.Substring(0, n);
        }
        else
        {
            return cadena.PadLeft(n, '0');
        }


    }

}
