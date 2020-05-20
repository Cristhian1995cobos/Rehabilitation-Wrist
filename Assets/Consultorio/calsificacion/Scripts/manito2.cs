using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manito2 : MonoBehaviour {
    private int aux = 0;
    public GameObject hapticTip;
    public GameObject godObject;
	// Use this for initialization
	void Start () {
        aux = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (contador.b_instanciar == 0)
        {
            GetComponent<MeshRenderer>().enabled = true;
            if (aux == 0)
            {

               
                hapticTip.transform.localScale = new Vector3(2f, 2f, 2f);
                godObject.transform.localScale = new Vector3(2f, 2f, 2f);
                aux = 1;
            }
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            aux = 0;
        }
	}
}
