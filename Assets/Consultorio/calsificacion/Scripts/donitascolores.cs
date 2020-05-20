using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donitascolores : MonoBehaviour {
    private int aux = 0;
	// Use this for initialization
	void Start () {
        aux = Random.Range(1, 37);
        if (aux < 10)
        {
            GetComponent<Renderer>().material.color = new Color(0, 34, 255, 1.0f);
        }
        else
        {
            if (aux < 20)
            {
                GetComponent<Renderer>().material.color = new Color(27, 185, 27, 1.0f);
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1.0f);
            }

        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
