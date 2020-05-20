using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mensaje : MonoBehaviour {
    public RawImage mensaje1;
    public Text texto;
	// Use this for initialization
	void Start () {
        mensaje1.enabled = false;
        texto.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (contador.mensaje == 1)
        {
            mensaje1.enabled = true;
            texto.enabled = true;
        }
        else
        {
            mensaje1.enabled = false;
            texto.enabled = false;
        }
    }
}
