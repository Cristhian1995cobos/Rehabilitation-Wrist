using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System;


public class rigidpaciente : MonoBehaviour {
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
        string sqlQuery = "SELECT * FROM CI_"+info.cedula+""; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        respuestaBase2 = "Paciente: "+info.nombre+"\nCédula:"+info.cedula+ "\t\t\t\t\t\tErrores/\nEjercicio\t Nivel\t   Tiempo (seg.)\tAciertos\t Peso\t Fecha\t\t  Hora\n_________________________________________________________________________________\n";

        while (reader.Read())
        {
            
            string ejercicio = reader.GetString(3);
            Int32 nivel= reader.GetInt32(4);
            float tiempo = reader.GetFloat(5);
            float errores = reader.GetFloat(6);
            string pesos = reader.GetString(7);
            string fecha = reader.GetString(8);
            string hora = reader.GetString(9);

            if (ejercicio == "CONSULTORIO")
            {
                respuestaBase += "" + limitStr(ejercicio, 11) + "\t   " + limitStr(nivel + "", 1) + "\t\t" + limitStL(tiempo + "", 8) + "\t   " + limitStL(errores + " A", 6) + "\t   " + limitStr(pesos, 1) + "\t" + limitStr(" ", 10) + "\t" + limitStr(hora, 8) + "\n";
            }
            else
            {
                if (ejercicio == "INICIO")
                {
                    respuestaBase += "" + limitStr("INICIO DE LA SESION", 52) +"\t" + limitStr(fecha, 10) + "\t" + limitStr(hora, 8) + "\n";
                }
                else
                {
                    if (ejercicio == "FINAL")
                    {
                        respuestaBase += "" + limitStr("FINAL DE LA SESION", 52) + "\t" + limitStr(fecha, 10) + "\t" + limitStr(hora, 8) + "\n";
                    }
                    else
                    {
                        respuestaBase += "" + limitStr(ejercicio, 11) + "\t   " + limitStr(nivel + "", 1) + "\t\t" + limitStL(tiempo + "", 8) + "\t   " + limitStL(errores + " E", 6) + "\t   " + limitStr(pesos, 1) + "\t" + limitStr(" ", 10) + "\t" + limitStr(hora, 8) + "\n";

                    }
                }
                }


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
            return cadena.PadRight(n, ' ');
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
            return cadena.PadLeft(n, ' ');
        }


    }

}