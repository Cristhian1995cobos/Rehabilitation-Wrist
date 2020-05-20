using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;

public class Menu : MonoBehaviour
{
    private string fecha;
    private string hora;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickLaberinto()
    {

        SceneManager.LoadScene("MENULABERINTOS");

    }
    public void ClickPUZZLE()
    {

        SceneManager.LoadScene("MENUPUZZLE");

    }
    public void ClickTALADRO()
    {

        SceneManager.LoadScene("MENUTALADRO");

    }
    public void ClickCONSULTORIO()
    {

        SceneManager.LoadScene("MENUCONSULTORIO");

    }

    public void Clicknuevo()
    {

        SceneManager.LoadScene("MENU REGISTRO");
    }
    public void Clickmenu()
    {
        SceneManager.LoadScene("MENU PRINCIPAL");
        guardar();
    }
    public void Clickmenu1()
    {
        SceneManager.LoadScene("MENU PRINCIPAL");
        
    }
    public void ClickSALIR()
    {
        SceneManager.LoadScene("LOGIN");
        guardar1();
    }
    public void ClickExit()
    {
        guardar1();
       // System.Diagnostics.Process.close (Application.dataPath + "/Plugins/FalconServer.exe");
        Application.Quit();

    }
    public void Clickdatos()
    {
        SceneManager.LoadScene("DatosENTERO");
    }
    public void Clickdatospaciente()
    {
        SceneManager.LoadScene("Datospaciente");
    }
    public void Clickdatospacientemenu()
    {
        SceneManager.LoadScene("Datospacientemenu");
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
        string sqlQuery = "INSERT INTO CI_" + info.cedula + " (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','INICIO','0','0','0','-','" + fecha + "','" + hora + "','0')";
        Debug.Log("log " + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


    }

    public void guardar1()
    {
        hora = System.DateTime.Now.Hour.ToString("00") + ":" + System.DateTime.Now.Minute.ToString("00") + ":" + System.DateTime.Now.Second.ToString("00");
        fecha = System.DateTime.Now.Day.ToString("00") + "/" + System.DateTime.Now.Month.ToString("00") + "/" + System.DateTime.Now.Year.ToString("0000");

        string conn = "URI=file:" + Application.dataPath + "/Plugins/BASEDATOS.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO CI_" + info.cedula + " (Nombres, cedula, Ejercicio, Nivel, Tiempo, errores, Peso, Fecha, Hora, Trayectoria) VALUES('" + info.nombre + "','" + info.cedula + "','FINAL','0','0','0','-','" + fecha + "','" + hora + "','0')";
        Debug.Log("log " + sqlQuery);

        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


    }

    public void ClickSALIR1()
    {
        SceneManager.LoadScene("LOGIN");
        
    }
    public void clickterminar()
    {
        Application.Quit();
    }

}
