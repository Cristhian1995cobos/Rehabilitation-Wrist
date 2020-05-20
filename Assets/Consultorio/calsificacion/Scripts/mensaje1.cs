using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mensaje1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (contador.ganador_consultorio == 1)
        {
            contador.mensaje =0;
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("colision");



        if (collision.gameObject.tag == "referencia" && contador.saber == 1)
        {
            contador.mensaje = 1;
            Debug.Log("mensaje" + contador.mensaje);
        }


    }
    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("colision");

      

        if (collision.gameObject.tag == "referencia" && contador.saber == 1)
        {
            contador.mensaje = 1;
            Debug.Log("mensaje" + contador.mensaje);
        }


    }

}
