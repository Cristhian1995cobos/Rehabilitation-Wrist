using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;



public class CONSULTARBASE : MonoBehaviour {

    public GameObject texto;
    public Text titulo;
    public Text titulo2;
    public Dropdown lista;
    public GameObject text1;

    List<string> listass = new List<string>();
    string nombre;
    int edad;
    string patologia;
    string fecha;
    string hora;
    int cedula;
    private string respuestaBase;
    private string respuestaBase2;
    private string respuestaBase3;

    // Use this for initialization
    void Start() {

        lista.ClearOptions();
        sqlite();
        lista.AddOptions(listass);
        titulo2.text = "\t\t\t\t\t\t\t\t\t\tErrores/\nEjercicio\t Nivel\t   Tiempo (seg.)\tAciertos\t Peso\t Fecha\t\t  Hora";
    }

    // Update is called once per frame
    void Update() {

    }

    public void botonlista()
    {
        respuestaBase = "";
        respuestaBase2 = "";
        
        string nombres = text1.GetComponent<Text>().text;
        Debug.Log(nombres);

        if (nombres != "Seleccionar")
        {
            string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * FROM Informacion WHERE Nombres=" + "'" + nombres + "'"; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
            Debug.Log("log" + sqlQuery);

            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                nombre = reader.GetString(1);
                cedula = reader.GetInt32(2);
                edad = reader.GetInt32(3);
                patologia = reader.GetString(4);
                fecha = reader.GetString(5);
                hora = reader.GetString(6);

            }
            Debug.Log(cedula);

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;


            conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.

            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * FROM CI_" + limitStLC(cedula + "", 10) + ""; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
            Debug.Log("log" + sqlQuery);





            dbcmd.CommandText = sqlQuery;
            reader = dbcmd.ExecuteReader();
            respuestaBase2 = "Paciente: " + limitStr(nombre, 20) + "\tCédula:" + limitStLC(cedula + "", 10) + "\t\t\tEdad:" + limitStr(edad + "", 3) + "\nPatología:" + limitStr(patologia, 15) + "\t\tFecha Registro:" + limitStr(fecha, 10) + "\tHora registro:" + limitStr(hora, 8) + "";

            while (reader.Read())
            {

                string ejercicio = reader.GetString(3);
                Int32 nivel = reader.GetInt32(4);
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
                        respuestaBase += "" + limitStr("INICIO DE LA SESION", 52) + "\t" + limitStr(fecha, 10) + "\t" + limitStr(hora, 8) + "\n";
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
        texto.GetComponent<Text>().text = respuestaBase;
        titulo.text = respuestaBase2;

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

    public string limitStLC(string cadena, int n)
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
        listass.Add("Seleccionar");
        while (reader.Read())
        {
            string nombre = reader.GetString(0);
            listass.Add(nombre);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
