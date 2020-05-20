using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System.Globalization;

public class Graficas : MonoBehaviour
{

    public Dropdown lista;
    public Dropdown lista2;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public Text mensaje;
    string fechas;
    string ejer;
    string niv;

    string fechaconsulta;
    
    List<string> listass = new List<string>();
    List<string> listas2 = new List<string>();
    int cedula;
    public WMG_Series numeros;
    public WMG_Axis_Graph xlabel;

    private List<Vector2> lista_datos = new List<Vector2>();
    string datos;
    private float[] valoresx;
    private float[] valoresy;
    private float[] num;
    private List<string> labelsx = new List<string>();
    private List<string> labelsy = new List<string>();
    void Start()
    {
        lista.ClearOptions();
        lista2.ClearOptions();
        sqlite();
        lista.AddOptions(listass);
       // graficar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void botonlista()
    {


        Debug.Log("entre");
        listas2 = new List<string>();
        lista2.ClearOptions();
        string nombres = text1.GetComponent<Text>().text;
        Debug.Log(nombres);
        ejer = text2.GetComponent<Text>().text;
        niv = text3.GetComponent<Text>().text;




        if (nombres != "Seleccionar" && ejer != "Seleccionar" && niv != "Seleccionar")
        {
            Debug.Log("entre");

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
    }

    public void botongrafico()
    {


        Debug.Log("entre");
        string nombres = text1.GetComponent<Text>().text;
        Debug.Log(nombres);
        ejer = text2.GetComponent<Text>().text;
        niv = text3.GetComponent<Text>().text;
        fechaconsulta = text4.GetComponent<Text>().text;




        if (nombres != "Seleccionar" && ejer != "Seleccionar" && niv != "Seleccionar"&& fechaconsulta != "Seleccionar")
        {
            Debug.Log("entre");

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
           // lista2.ClearOptions();
            sqlitd2();
//            lista2.AddOptions(listas2);
        }
    }



    public void sqlitd()
    {
        if (ejer == "LABERINTO") { ejer = "Laberinto"; }
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT Fecha FROM CI_" + limitStLC(cedula + "", 10) + " WHERE Ejercicio='" + ejer + "' AND Nivel=" + niv + ""; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        listas2.Add("Seleccionar");
        while (reader.Read())
        {
            fechas = reader.GetString(0);
            listas2.Add(fechas);

        }


    }
    public void sqlitd2()
    {
        if (ejer == "LABERINTO") { ejer = "Laberinto"; }
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT Trayectoria FROM CI_" + limitStLC(cedula + "", 10) + " WHERE Ejercicio='" + ejer + "' AND Nivel=" + niv + " AND Fecha='" + fechaconsulta+"' "; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);


        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
       // listas2.Add("Seleccionar");
        while (reader.Read())
        {
            fechas = reader.GetString(0);
            // listas2.Add(fechas);
           // Debug.Log(fechas);

        }
        if (fechas == "-")
        {
            mensaje.text = "EN LA FECHA SOLICITADA NO SE TOMARON SUFICIENTES DATOS DE LA TRAYECTORIA";
            datos = "0,0,";
            limites();
            graficar();
        }
        else
        {
            datos = fechas;
            mensaje.text = "";
            limites();
            graficar();

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

    public void graficar()
    {
        numeros.pointValues.Clear();
        string[] num_string = datos.Split(',');

        valoresx = new float[num_string.Length / 2];
        int d = 0;
        for (int i = 0; i < num_string.Length - 1; i = i + 2)
        {
            valoresx[d] = float.Parse(num_string[i], new CultureInfo("en-US").NumberFormat);
            d++;
        }
        valoresy = new float[num_string.Length / 2];
        int f = 0;
        for (int i = 1; i <= num_string.Length - 1; i = i + 2)
        {
            valoresy[f] = float.Parse(num_string[i], new CultureInfo("en-US").NumberFormat);
            Debug.Log(valoresy[f]);
            f++;
        }

        crear_lista(valoresx, valoresy);
        numeros.pointValues = new List<Vector2>();
        numeros.pointValues = lista_datos;
        xlabel.xAxisLabels = new List<string>();
        xlabel.yAxisLabels = new List<string>();
      
    }

    void limites()
    {
        switch(ejer)
        {
            case "Laberinto":
                switch(niv)
                {
                    case "1": mandar_limites(7f, -3f, 4f, -2f);
                        break;
                    case "2":mandar_limites(9f, -5f, 4.5f, -2.5f);
                        numeros.theGraph.numDecimalsYAxisLabels = 1;
                        break;
                    case "3":
                        mandar_limites(8, -5,5, -3);
                        break;
                }
                break;
            case "TALADRO":
                switch (niv)
                {
                    case "1":
                        mandar_limites(30, -30, 20, -5);
                        break;
                    case "2":
                        mandar_limites(25,-35, 30 , -35);
                        break;
                    case "3":
                        mandar_limites(40, -40, 30, -30);
                        break;
                }
                break;

        }        
        

    }
    void mandar_limites(float maxx, float minx, float maxy, float miny)
    {
        numeros.theGraph.numDecimalsYAxisLabels = 0;
        numeros.theGraph.xAxisMaxValue = maxx;
        numeros.theGraph.xAxisMinValue = minx;
        if((maxx - minx + 1)>15)
        {
            numeros.theGraph.xAxisNumTicks = Convert.ToInt16((maxx - minx + 1) / 4);
        }
        else
        {
            numeros.theGraph.xAxisNumTicks = Convert.ToInt16((maxx - minx + 1));
        }

        numeros.theGraph.yAxisMaxValue = maxy;
        numeros.theGraph.yAxisMinValue = miny;
        if ((maxy - miny + 1) > 15)
        {
            numeros.theGraph.yAxisNumTicks = Convert.ToInt16((maxy - miny + 1)/4);
        }
        else
        {
            numeros.theGraph.yAxisNumTicks = Convert.ToInt16((maxy - miny + 1));
        }

    }
    void crear_lista(float[] X, float[] Y)
    {
        for (int i = 0; i < X.Length; i++)
        {
           lista_datos.Add(new Vector2(X[i], Y[i]));
        }
    }
}





