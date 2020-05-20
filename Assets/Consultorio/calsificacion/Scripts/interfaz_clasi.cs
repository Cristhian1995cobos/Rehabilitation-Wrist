using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;


public class interfaz_clasi : MonoBehaviour {

    private float time = 0;
    public Text tiempo;
    public Text errores;
    public GameObject panel;
    public GameObject panelganador;
    public GameObject can;
    public GameObject warming;
    public GameObject permiti;
    public Camera camara;

    private int NIV;
    private int solo;
    private Scene m_Scene;
    public Vector3 constantforce;
    public Text error;
    public Text empieza;
    public Text mensaje;
    private string pesotexto;
    private string fecha;
    private string hora;
    private float timebase = 0;
    private float peso = 0;
    private int aux = 0;
    public GameObject base_niv;
    public GameObject mesa;
    public GameObject figuras;
    // Use this for initialization
    void Start()
    {

        contador.acierto=0;
        aux = 0;
        solo = 0;
       FalconUnity.setForceField(0, constantforce);
        contador.b_instanciar = 1;
        peso = 0;
        timebase = 0;
        m_Scene = SceneManager.GetActiveScene();
        
    }


    void Update()
    {


        if (time>130)
        {
            panelganador.transform.position = can.transform.position;
            error.text = "Tu num. de aciertos fue de: " + contador.acierto;
            peso = -contador.peso;
            timebase = time - 10;
            
            contador.ganador_consultorio = 1;
            camara.enabled = false;
            if (m_Scene.name == "consultorioniv3")
            {
               // Debug.Log("nivel3");
                
                GameObject[] donas = GameObject.FindGameObjectsWithTag("azul1");
                foreach (GameObject d in donas)
                    Destroy(d);
                donas = GameObject.FindGameObjectsWithTag("azul2");
                foreach (GameObject d in donas)
                    Destroy(d);
                 donas = GameObject.FindGameObjectsWithTag("azul3");
                foreach (GameObject d in donas)
                    Destroy(d);
               donas = GameObject.FindGameObjectsWithTag("rojo1");
                foreach (GameObject d in donas)
                    Destroy(d);
                donas = GameObject.FindGameObjectsWithTag("rojo2");
                foreach (GameObject d in donas)
                    Destroy(d);
                 donas = GameObject.FindGameObjectsWithTag("rojo3");
                foreach (GameObject d in donas)
                    Destroy(d);
                 donas = GameObject.FindGameObjectsWithTag("verde1");
                foreach (GameObject d in donas)
                    Destroy(d);
                donas = GameObject.FindGameObjectsWithTag("verde2");
                foreach (GameObject d in donas)
                    Destroy(d);
                 donas = GameObject.FindGameObjectsWithTag("verde3");
                foreach (GameObject d in donas)
                    Destroy(d);
            }
        }
        else
        {

            time += Time.deltaTime;
            empieza.text = "EMPIEZA EN: " + System.Math.Round((10 - time), 0) + "seg";
           
            if (time > 10)
            {
                    camara.enabled = true;
                FalconUnity.setForceField(0,new Vector3(0, 0, 0));
               panel.transform.position = panelganador.transform.position;
                tiempo.text = "Tiempo: " +System.Math.Round(120-(time - 10), 0)+"seg";
                errores.text = "Aciertos: " + contador.acierto;
                contador.errores = contador.acierto;
                if (aux == 0) {
                    contador.ganador_consultorio = 0;
                    aux = aux + 1;
                    
                }

            }
            else
            {
                if (time > 5&& solo==0)
                {
                    
                    permiti.transform.localPosition = warming.transform.localPosition;
                    warming.transform.localPosition = new Vector3(1000, 1000, 1000);
                    solo = 1;
                    contador.permiso = 0;
                    contador.b_instanciar = 0;
                    FalconUnity.setForceField(0, new Vector3(0, -6, 0));
                

                    m_Scene = SceneManager.GetActiveScene();
                    if (m_Scene.name == "consultorioniv1")
                    {
                        Instantiate(mesa, new Vector3(-4.179646f, -15.7f, 6.1f), Quaternion.Euler(new Vector3(-90, 180, 0)));
                        Instantiate(base_niv, new Vector3(9.31f, -10.424f, 7.95f), Quaternion.Euler(new Vector3(90, 180, 0)));
                        Instantiate(figuras, new Vector3(-15.04f, -12.16f, 6.87f), Quaternion.Euler(new Vector3(90, 0, 0)));
                    }
                    if (m_Scene.name == "consultorioniv2")
                    {
                        Instantiate(mesa, new Vector3(-4.179646f, -15.7f, 6.1f), Quaternion.Euler(new Vector3(-90, 180, 0)));
                        Instantiate(base_niv, new Vector3(3.62f, -9.36f, 5.4f), Quaternion.Euler(new Vector3(-90, 0, 0)));
                        Instantiate(figuras, new Vector3(3.625f, -13.876f, 5.46f), Quaternion.Euler(new Vector3(90, 0, 0)));
                    }
                }
            }
        }
    }


    public void Click()
    {
        //FalconUnity.setForceField(0, constantforce);
        Debug.Log("finalizo");
        m_Scene = SceneManager.GetActiveScene();
        Debug.Log(m_Scene.name);


        if (m_Scene.name == "consultorioniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "consultorioniv2")
        {
            NIV = 2;
        }


       guardar();
        if (m_Scene.name == "consultorioniv1")
        {

            SceneManager.LoadScene("consultorioniv2");
        }
        if (m_Scene.name == "consultorioniv2")
        {

            SceneManager.LoadScene("consultorioniv3");
        }



    }

    public void ClickRESET()
    {
        FalconUnity.setForceField(0, constantforce);

        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "consultorioniv1")
        {

            SceneManager.LoadScene("consultorioniv1");
        }
        if (m_Scene.name == "consultorioniv2")
        {

            SceneManager.LoadScene("consultorioniv2");
        }
        if (m_Scene.name == "consultorioniv3")
        {
            contador.reseteo = 0;
            SceneManager.LoadScene("consultorioniv3");
        }


    }



    public void Clicksalir()
    {
        FalconUnity.setForceField(0, constantforce);
        m_Scene = SceneManager.GetActiveScene();


        if (m_Scene.name == "consultorioniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "consultorioniv2")
        {
            NIV = 2;
        }
        if (m_Scene.name == "consultorioniv3")
        {
            NIV = 3;
        }

        guardar();
        SceneManager.LoadScene("MENUCONSULTORIO");

    }

    public void Clicksalir2()
    {
       // FalconUnity.setForceField(0, constantforce);

        SceneManager.LoadScene("MENUCONSULTORIO");
    }

    public void guardar()
    {
        hora = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
        fecha = System.DateTime.Now.Day.ToString("00") + "/" + System.DateTime.Now.Month.ToString("00") + "/" + System.DateTime.Now.Year.ToString("0000");
        pesotexto = "" + peso + "";
        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO CI_" + info.cedula + " (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','CONSULTORIO','" + NIV + "','120','" + contador.errores + "','-','" + fecha + "','" + hora + "','-')";
        Debug.Log("log " + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


    }

  
}
