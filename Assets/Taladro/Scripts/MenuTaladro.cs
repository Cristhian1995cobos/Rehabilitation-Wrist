using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTaladro : MonoBehaviour {
    
      

    // Use this for initialization
    void Start()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, -8));
        contador.aciertos = 0;
        //   Debug.Log("fuerza");
    }

    void Update()
    {

    }

    public void ClickTaladro1()
    {

        SceneManager.LoadScene("taladroniv1");
    }
    public void ClickTaladro2()
    {

        SceneManager.LoadScene("taladroniv2");
    }
    public void ClickLTaladro3()
    {

        SceneManager.LoadScene("taladroniv3");
    }
    public void ClickSalir()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, 0));
        SceneManager.LoadScene("MENU PRINCIPAL");

    }
}
