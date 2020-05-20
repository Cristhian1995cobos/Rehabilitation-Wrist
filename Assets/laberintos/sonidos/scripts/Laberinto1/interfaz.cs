using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class interfaz : MonoBehaviour
{

    public Text textchoques;
    public Text cronometro;
    public Text tiempo;
    public Text indicador;
    public RawImage great;
    public RawImage bien;
    public RawImage malo;
    public RawImage buen;
    public RawImage normal;
    public RawImage mal;
    public int falcon_num = 0;
    public Vector3 constantforce2;
    private Scene m_Scene;
    public RawImage llegada;
    public GameObject moneda;
    public int NIV;
    public RawImage imagen1;
    public RawImage imagen2;
    private string fecha;
    private string hora;
    public GameObject warming;
    public GameObject permiti;
    public int solo = 0;



    public Button seguir;
    private float timer = 0.0f;
    private float waitTime = 1.0f;


    public float time = 0;
    public GameObject mensaje;
    public float indice;
    public int aux;
    private string trayectoriabase;
    public int aux2;
    private int guardatrayec = 900;
    private bool aux3 = false;
    // Use this for initialization
    void Start()
    {
        llegada.enabled = true;
       // moneda.GetComponent<MeshRenderer>().enabled = true;
        timer = 0.0f;
        waitTime = 30f;
        seguir.enabled = false;
        great.enabled = false;
        bien.enabled = false;
        malo.enabled = false;
        buen.enabled = false;
        normal.enabled = false;
        mal.enabled = false;
        aux = 0;
        aux2 = 0;
        NIV = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (aux == 0)
        {
            indice = contador.numero_choques;// / 10f;
        }

        textchoques.text = "Error: " + indice;
        if (aux2 < 10000)
        {

           
                    seguir.enabled = true;
             

            if (contador.numero_llegada == 1)
            {
                contador.fuerza = 1;
                FalconUnity.setForceField(0, constantforce2);
                aux = 1;
                mensaje.transform.localPosition = new Vector3(0, 0, 0);
                Destroy(cronometro);
                Destroy(textchoques);
                Destroy(imagen1);
                Destroy(imagen2);
                contador.cronometro = 0;

                if (time > 100)
                {
                    malo.enabled = true;
                }
                else
                {
                    if (time > 600)
                    {
                        bien.enabled = true;
                    }
                    else
                    {
                        great.enabled = true;
                    }
                }

                if (indice > 200)
                {
                    mal.enabled = true;
                }
                else
                {
                    if (indice > 100)
                    {
                        normal.enabled = true;
                        mal.enabled = true;
                    }
                    else
                    {
                        buen.enabled = true;
                        normal.enabled = true;
                        mal.enabled = true;
                    }
                }


                //  FalconUnity.setGravity(constantforce2);
                //    FalconUnity.setForceField(0, constantforce2);



            }
            aux2 = aux2 + 1;
            //           Debug.Log("entre");
        }

        if (contador.cronometro == 1)
        {
            time += Time.deltaTime;
            Vector3 trayec = new Vector3(0,0,0);
            FalconUnity.getGodPosition(0, out trayec);
            //Debug.Log(trayec);

            guardatrayec = guardatrayec + 1;
            if (guardatrayec > 25)
            {
                trayectoriabase += "" + trayec.x + "," + trayec.y + ",";
                Debug.Log(trayectoriabase);
                guardatrayec = 0;
            }



        }
        else
        {
            contador.numero_choques =0;        }
            cronometro.text = "Tiempo:" + System.Math.Round(time,2);//.ToString("f0");
        tiempo.text = "Tu tiempo fue de : " + System.Math.Round(time,2) + " seg.";
        indicador.text = "Tu indice fue : " + indice;
        

    }
  
    private void LateUpdate()
    {
        if (contador.fuerza == 1)
        {
            FalconUnity.removeDynamicShape(contador.bodytecho);
            //FalconUnity.setForceField(0, constantforce2);
            Destroy(moneda);
            Destroy(GameObject.FindWithTag("paredes"));
            
            Debug.Log("sin nombre");
        
            llegada.enabled = false;

        }
    }

    public void Click()
    {
        FalconUnity.setForceField(0, constantforce2);
        int d = 0;
        while (d < 1000)
        {

            d++;
            Debug.Log(d);
        }
        Debug.Log("finalizo");
        m_Scene = SceneManager.GetActiveScene();
        Debug.Log(m_Scene.name);
        llegada.enabled = false;

        if (m_Scene.name == "laberintonivel1sinregistro")
        {
            NIV = 1;
        }
        if (m_Scene.name == "laberintonivel2")
        {
            NIV = 2;
        }
        if (m_Scene.name == "laberintonivel3")
        {
            NIV = 3;
        }




       guardar();
        if (m_Scene.name == "laberintonivel1sinregistro")
        {

            SceneManager.LoadScene("laberintonivel2");
        }
        if (m_Scene.name == "laberintonivel2")
        {

            SceneManager.LoadScene("laberintonivel3");
        }
      

    }

    public void ClickRESET()
    {
        for (int i = 0; i <= contador.bodytecho; i++)
        {
            FalconUnity.removeDynamicShape(i);
        }
        FalconUnity.setForceField(0, new Vector3(0, 0, -6));
        int d = 0;
        while (  d < 500){
           
            d++;
            Debug.Log(d);
        }



        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "laberintonivel1sinregistro")
        {

            SceneManager.LoadScene("laberintonivel1sinregistro");
        }
        if (m_Scene.name == "laberintonivel2")
        {

            SceneManager.LoadScene("laberintonivel2");
        }
        if (m_Scene.name == "laberintonivel3")
        {

            SceneManager.LoadScene("laberintonivel3");
        }
    }



    public void Clicksalir()
    {
        FalconUnity.setForceField(0, new Vector3(0,0,0));
        int d = 0;
        while (d < 500)
        {

            d++;
            Debug.Log(d);
        }
        m_Scene = SceneManager.GetActiveScene();
        

        if (m_Scene.name == "laberintonivel1sinregistro")
        {
            NIV = 1;
        }
        if (m_Scene.name == "laberintonivel2")
        {
            NIV = 2;
        }
        if (m_Scene.name == "laberintonivel3")
        {
            NIV = 3;
        }




        guardar();
        SceneManager.LoadScene("MENULABERINTOS");
    }

    public void Clicksalir2()
    {
        FalconUnity.removeDynamicShape(contador.bodytecho);
        FalconUnity.setForceField(0, new Vector3(0, 0, 0));
        int d = 0;
        while (d < 500)
        {

            d++;
           // Debug.Log(d);
        }
        SceneManager.LoadScene("MENULABERINTOS");
    }

    public void guardar()
    {
        hora = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
        fecha = System.DateTime.Now.Day.ToString("00") + "/" + System.DateTime.Now.Month.ToString("00") + "/" + System.DateTime.Now.Year.ToString("0000");

        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO CI_" +info.cedula+" (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','Laberinto','"+NIV+"','"+ System.Math.Round(time, 2) + "','"+indice+ "','-','" + fecha+"','"+hora+"','"+trayectoriabase+"')";
        Debug.Log("log " + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

}
