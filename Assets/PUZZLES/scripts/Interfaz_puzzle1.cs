using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;



public class Interfaz_puzzle1 : MonoBehaviour {
    private float time = 0;
    public Text tiempo;
    public Text errores;
    public RawImage manito;
    public RawImage ojito;
    public Text modo;
    public GameObject panel;
    public GameObject panelganador;
    public GameObject can;
    private int NIV;
    private Scene m_Scene;
    public Vector3 constantforce;
    public Text tiempofinal;
    public Text error;
    public Text empieza;
    private string pesotexto;
    private string fecha;
    private string hora;
    private float timebase = 0;
    private float peso = 0;
    public GameObject warming;
    public GameObject permiti;
    private int solo;
    // Use this for initialization
    void Start () {
        FalconUnity.applyForce(0, constantforce,0.01f);
        peso = 0;
        timebase = 0;
}
	
	// Update is called once per frame
	void Update () {


        if (contador.ganador == 1)
        {
            panelganador.transform.position = can.transform.position;
            tiempofinal.text = "Tu tiempo fue de: " + System.Math.Round(time - 12, 2) + "seg";
            error.text = "Tu num. de errores fue de: " + contador.errores;
            peso = -contador.peso;
            timebase = time - 12;

        }
        else
        {
            time += Time.deltaTime;
            
            if (time > 12)
            {
                Destroy(panel);
                tiempo.text = "Tiempo: " + System.Math.Round(time - 12, 2);
                errores.text = "Errores: " + contador.errores;
                if (contador.pieza == 1)
                {
                    manito.enabled = true;
                    ojito.enabled = false;
                    modo.text = "Agarrar";
                }
                else
                {
                    ojito.enabled = true;
                    manito.enabled = false;
                    modo.text = "Observar";
                }
            }
            else { empieza.text = "EMPIEZA EN: " + System.Math.Round((12 - time), 0) + "seg";
                if (time > 5 && solo == 0)
                {

                    permiti.transform.localPosition = warming.transform.localPosition;
                    warming.transform.localPosition = new Vector3(1000, 1000, 1000);
                    solo = 1;

                }
            }
        }
    }


    public void Click()
    {
        FalconUnity.setForceField(0, constantforce);
        Debug.Log("finalizo");
        m_Scene = SceneManager.GetActiveScene();
        Debug.Log(m_Scene.name);
        

        if (m_Scene.name == "puzzleniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "puzzleniv2")
        {
            NIV = 2;
        }
        

        guardar();
        if (m_Scene.name == "puzzleniv1")
        {

            SceneManager.LoadScene("puzzleniv2");
        }
        if (m_Scene.name == "puzzleniv2")
        {

            SceneManager.LoadScene("puzzleniv3");
        }



    }

    public void ClickRESET()
    {
        FalconUnity.setForceField(0, constantforce);

        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "puzzleniv1")
        {

            SceneManager.LoadScene("puzzleniv1");
        }
        if (m_Scene.name == "puzzleniv2")
        {

            SceneManager.LoadScene("puzzleniv2");
        }
        if (m_Scene.name == "puzzleniv3")
        {

            SceneManager.LoadScene("puzzleniv3");
        }


    }



    public void Clicksalir()
    {
        FalconUnity.setForceField(0, constantforce);
        m_Scene = SceneManager.GetActiveScene();


        if (m_Scene.name == "puzzleniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "puzzleniv2")
        {
            NIV = 2;
        }
        if (m_Scene.name == "puzzleniv3")
        {
            NIV = 3;
        }

        guardar();
        SceneManager.LoadScene("MENUPUZZLE");

    }

    public void Clicksalir2()
    {
        FalconUnity.setForceField(0, constantforce);

        SceneManager.LoadScene("MENUPUZZLE");
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
          string sqlQuery = "INSERT INTO CI_" + info.cedula + " (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','PUZZLES','" + NIV + "','" + System.Math.Round(timebase, 2) + "','" + contador.errores + "','" + pesotexto + "','" + fecha + "','" + hora + "','-')";
          Debug.Log("log " + sqlQuery);

          dbcmd.CommandText = sqlQuery;
          dbcmd.ExecuteNonQuery();

          dbcmd.Dispose();
          dbcmd = null;
          dbconn.Close();
          dbconn = null;
          

    }



}
