using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuConsultorio : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, -8));
        Debug.Log("fuerza");
        contador.reseteo = 0;
    }

    void Update()
    {

    }

    public void ClickConsultorio1()
    {

        SceneManager.LoadScene("consultorioniv1");
    }
    public void ClickConsultorio2()
    {

        SceneManager.LoadScene("consultorioniv2");
    }
    public void ClickLConsultorio3()
    {

        SceneManager.LoadScene("consultorioniv3");
    }
    public void ClickSalir()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, 0));
        SceneManager.LoadScene("MENU PRINCIPAL");

    }
}
