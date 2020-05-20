using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;

public class interfaz_taladro : MonoBehaviour {
    private float time1 = 0;
    public Text tiempo1;
    public GameObject taladro;
    private float timebase = 0;
    public GameObject panel;
    public GameObject broca;
    public GameObject panelganador;
    public Text tiempofinal;
    public Text error;
    private string trayectoriabase;
    public Text empieza;
    private int NIV;
    public Text indice; private Scene m_Scene;
    public Vector3 constantforce;
    private string pesotexto;
    private string fecha;
    private string hora;
    private float peso = 0;
    private int auxinicial = 0;
    private int hollos = 0;
    public GameObject warming;
    public GameObject permiti;
    private int solo;
    private int guardatrayec = 900;
    

    // Use this for initialization
    void Start () {
        //peso = 0;
        guardatrayec = 0;
        contador.broca = 1;
        timebase = 0;
        time1 = 0;
        auxinicial = 0;
        hollos = 3;
        
        taladro.GetComponent<MeshRenderer>().enabled = false;
        broca.GetComponent<MeshRenderer>().enabled = false;
        panel.transform.position = GetComponent<Transform>().position;
        contador.aciertos = 0;
        contador.error_taladro = 0;
        contador.ganador_taladro = 0;
      
    }
	
	// Update is called once per frame
	void Update () {
        
        if (contador.aciertos == hollos)
        {
            Debug.Log("Finalice" + hollos + "" + contador.aciertos + "");
            taladro.GetComponent<MeshRenderer>().enabled = false;
            broca.GetComponent<MeshRenderer>().enabled = false;
            panelganador.transform.position = GetComponent<Transform>().position;
            tiempofinal.text = "Tu tiempo fue de: " + System.Math.Round( time1-10, 2) + "seg";
            error.text = "Tu num. de errores fue de: " + contador.error_taladro;
            
            timebase = time1 - 10;
            contador.ganador_taladro = 1;
            FalconUnity.setForceField(0, new Vector3(0, 0, -8));
            peso = contador.peso_taladro;

        }
        else
        {
            Debug.Log(hollos); 
            time1 += Time.deltaTime;
           
                if (time1 > 10)
                {
                taladro.GetComponent<MeshRenderer>().enabled = true;
                broca.GetComponent<MeshRenderer>().enabled = true;
                panelganador.transform.position = new Vector3(100,100,100);
                Vector3 trayec = new Vector3(0, 0, 0);
                FalconUnity.getGodPosition(0, out trayec);

                guardatrayec = guardatrayec + 1;
                if (guardatrayec > 25)
                {
                    trayectoriabase += "" + trayec.x + "," + trayec.y + ",";
                  //  Debug.Log(trayectoriabase);
                    guardatrayec = 0;
                }


                FalconUnity.setForceField(0, new Vector3(0, 0, 0));
                taladro.GetComponent<MeshRenderer>().enabled = true;
                broca.GetComponent<MeshRenderer>().enabled = true;
                Destroy(panel);
                tiempo1.text = "Tiempo: " + System.Math.Round(time1 - 10, 2);
                contador.ganador_taladro = 0;
                indice.text = "Error: " + System.Math.Round(contador.error_taladro, 0);
                }
            else {
                contador.error_taladro = 0;
                contador.aciertos = 0;
                if (time1 > 5 && solo == 0)
                {

                    permiti.transform.localPosition = warming.transform.localPosition;
                    warming.transform.localPosition = new Vector3(1000, 1000, 1000);
                    solo = 1;
                }
                empieza.text = "EMPIEZA EN: " + System.Math.Round((10 - time1), 0) + "seg";
                GameObject[] donas = GameObject.FindGameObjectsWithTag("llegada1");
                foreach (GameObject d in donas)
                    d.SetActive(false);
            }

        }
    }



    public void Click()
    {
        FalconUnity.setForceField(0, constantforce);
        Debug.Log("finalizo");
        m_Scene = SceneManager.GetActiveScene();
        Debug.Log(m_Scene.name);


        if (m_Scene.name == "taladroniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "taladroniv2")
        {
            NIV = 2;
        }


        guardar();
        if (m_Scene.name == "taladroniv1")
        {

            SceneManager.LoadScene("taladroniv2");
        }
        if (m_Scene.name == "taladroniv2")
        {

            SceneManager.LoadScene("taladroniv3");
        }



    }

    public void ClickRESET()
    {
        FalconUnity.setForceField(0, constantforce);

        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "taladroniv1")
        {

            SceneManager.LoadScene("taladroniv1");
        }
        if (m_Scene.name == "taladroniv2")
        {

            SceneManager.LoadScene("taladroniv2");
        }
        if (m_Scene.name == "taladroniv3")
        {

            SceneManager.LoadScene("taladroniv3");
        }


    }



    public void Clicksalir()
    {
        FalconUnity.setForceField(0, constantforce);
        m_Scene = SceneManager.GetActiveScene();


        if (m_Scene.name == "taladroniv1")
        {
            NIV = 1;
        }
        if (m_Scene.name == "taladroniv2")
        {
            NIV = 2;
        }
        if (m_Scene.name == "taladroniv3")
        {
            NIV = 3;
        }

        guardar();
        SceneManager.LoadScene("MENUTALADRO");

    }

    public void Clicksalir2()
    {
        FalconUnity.setForceField(0, constantforce);

        SceneManager.LoadScene("MENUTALADRO");
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
        string sqlQuery = "INSERT INTO CI_" + info.cedula + " (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','TALADRO','" + NIV + "','" + System.Math.Round(timebase, 2) + "','" + contador.error_taladro + "','" + pesotexto + "','" + fecha + "','" + hora + "','"+trayectoriabase+"')";
        Debug.Log("log " + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    
    }
}
