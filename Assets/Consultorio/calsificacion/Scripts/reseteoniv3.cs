using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class reseteoniv3 : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (contador.reseteo < 4)
        {
            Debug.Log("reseteo");
            contador.reseteo = contador.reseteo + 1;
            SceneManager.LoadScene("consultorioniv3");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
