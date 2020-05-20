using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class escribirbasedatos : MonoBehaviour
{

    public InputField Input1;
    
    public InputField Input3;
    public GameObject Input4;
    public RawImage cuadro;

    public Text anadido;

    private int aux;
    private string paciente;

    private string fecha;
    private string hora;
    public Button anadirusuario;
   

    private void Start()
    {
        aux= 0;
        cuadro.enabled = false;
        info.tabla = 0;
       
        
    }

    private void Update()
    {
       
       // Debug.Log(aux);
      


    }

    public void aplastar()
    {
        cuadro.enabled = true;
        
        if (Input1.text=="" || Input3.text =="" )
        {
            anadido.text = "Complete todos los campos";
            info.tabla = 0;
        }
        else
        {
            sqlite();
            Debug.Log("lleno");
            info.tabla = 1;
            anadirusuario.gameObject.SetActive(false);

        }


    }

    public void sqlite()
    {
        hora = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
        fecha = System.DateTime.Now.Day.ToString("00") + "/" + System.DateTime.Now.Month.ToString("00") + "/" + System.DateTime.Now.Year.ToString("0000");



        aux = 0;
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO informacion (Nombres, cedula, edad, patologia, Fecha, Hora) VALUES('" + Input1.text + "','0" + info.cedula+ "','" + Input3.text + "','" + Input4.GetComponent<Text>().text + "','"+fecha+"','"+hora+"' )" ;
        Debug.Log("log " + sqlQuery);

        anadido.text = "Usuario Añadido";

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

}
