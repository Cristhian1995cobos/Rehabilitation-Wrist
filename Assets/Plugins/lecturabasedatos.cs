using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class lecturabasedatos : MonoBehaviour {

    public GameObject Input;
    public RawImage usuario;
    public Text nombres;
    public Button ejer1;
    //public Button ejer2;


    public Button borraren;
    public Button registraren;

    private string paciente;
    private string ced;
    private string cant;
    private int cont;



    private void Start()
    {
        cant = "";
        cont = 0;
        usuario.enabled = false;
        nombres.text = "Usuario no registrado";
        nombres.enabled = false;
        ejer1.gameObject.SetActive (false);
       // ejer2.gameObject.SetActive(false);


        borraren.gameObject.SetActive(false);
        registraren.gameObject.SetActive(false);

    }

    public void sqlite()
    {
        borraren.gameObject.SetActive(false);
        registraren.gameObject.SetActive(false);
        cant = "";
        cont = 0;

        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM informacion WHERE cedula =" + Input.GetComponent<Text>().text; // para elegir uno en aprticular (FROM informacion WHERE id = 1)
        Debug.Log("log" + sqlQuery);
        
        
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        paciente = "";
        ced = "";
        cant = Input.GetComponent<Text>().text;
        ced = Input.GetComponent<Text>().text;

        while (reader.Read())
        {
           int  id = reader.GetInt32(0);
           string nombre = reader.GetString(1);
           Int32  cedula= reader.GetInt32(2);
           int  edad = reader.GetInt32(3);

            Debug.Log("id= " + id + "  nombre =" + nombre + "  cedula =" + cedula + "  edad =" + edad);
            paciente = nombre;
           
           

        }

        Debug.Log(paciente);

        cont = cant.Length;


        ejer1.gameObject.SetActive(false);

      //  ejer2.gameObject.SetActive(false);



        if (cont < 10)
        {
            usuario.enabled = true;
            nombres.enabled = true;
            nombres.text = "Número de cédula no valido";
            
        }
        else
        {

            if (paciente == "")
            {
                usuario.enabled = true;
                nombres.enabled = true;
                nombres.text = "Usuario no registrado";
                info.cedula = ced;
                Debug.Log(info.cedula);

                registraren.gameObject.SetActive(true);
  
            }
            else
            {
                usuario.enabled = true;
                nombres.enabled = true;
                nombres.text = "Bienvenido " + paciente;
                info.nombre = paciente;
                info.cedula = ced;
                Debug.Log("nombresssssss" + info.nombre);
                Debug.Log("cedu" + info.cedula);

                borraren.gameObject.SetActive(true);

                ejer1.gameObject.SetActive(true);
               // ejer2.gameObject.SetActive(true);



            }


        
        }


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        
    }

}


