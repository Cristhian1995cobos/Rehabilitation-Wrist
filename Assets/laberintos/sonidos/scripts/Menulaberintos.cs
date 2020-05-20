using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menulaberintos : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, -8));
        Debug.Log("fuerza");
    }

    void Update()
    {
        
    }

    public void ClickLaberinto1()
    {

        SceneManager.LoadScene("laberintonivel1sinregistro");
    }
    public void ClickLaberinto2()
        {

            SceneManager.LoadScene("laberintonivel2");
        }
    public void ClickLaberinto3()
        {

            SceneManager.LoadScene("laberintonivel3");
        }
    public void ClickSalir()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, 0));
        SceneManager.LoadScene("MENU PRINCIPAL");

    }


}
