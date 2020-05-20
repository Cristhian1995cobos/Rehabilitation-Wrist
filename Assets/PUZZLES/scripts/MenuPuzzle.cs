using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPuzzle : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, -8));
        Debug.Log("fuerza");
    }

    void Update()
    {

    }

    public void ClickPuzzle1()
    {

        SceneManager.LoadScene("puzzleniv1");
    }
    public void ClickPuzzle2()
    {

        SceneManager.LoadScene("puzzleniv2");
    }
    public void ClickLPuzzle3()
    {

        SceneManager.LoadScene("puzzleniv3");
    }
    public void ClickSalir()
    {
        FalconUnity.setForceField(0, new Vector3(0, 0, 0));
        SceneManager.LoadScene("MENU PRINCIPAL");

    }
}
