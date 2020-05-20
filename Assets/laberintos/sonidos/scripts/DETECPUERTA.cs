using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DETECPUERTA : MonoBehaviour {
    private int aux = 0;
    public GameObject bloqentrada;
    // Use this for initialization
    void Start () {
        aux = 0;
        contador.ini = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colision");

        if (aux == 0 && collision.gameObject.tag == "verde1" && contador.ini == 1)
        {
            Instantiate(bloqentrada, new Vector3(GetComponent<Transform>().position.x-0.4f, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z), transform.rotation);
            aux = 1;
            contador.puerta = 1;


        }

    }
}
