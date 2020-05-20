using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reconocer : MonoBehaviour {
    public string pieza = "";
    public string pieza2 = "";
    private GameObject p1;
    public GameObject referencia;
    public int aux = 0;
    // Use this for initialization
    void Start () {
        pieza = "";
        pieza2 = "";
        aux = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (aux == 1)
        {
            if (contador.pieza == 0)
            {
                p1 = GameObject.Find(pieza);
                pieza2 = "" + pieza + " (1)";
                Debug.Log(pieza2);
                if (pieza2 == referencia.gameObject.name)
                {
                    p1.gameObject.transform.position = referencia.transform.position;
                    Debug.Log("logrado");
                }
                
            }
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "piezas")
        {
            //prender halo


            Debug.Log("entreeeeeee0");
                pieza = collision.gameObject.name;
                aux = 1;
            

        }
     }

}
