using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciacion : MonoBehaviour {
    public GameObject cubo;
    public GameObject cilindro;
    public GameObject octa;
    public GameObject hapticTip;
    public GameObject god;
    private int forma;
    private int aux;
    private Vector3 gravedad= new Vector3(0,0,0);
    static  Vector3 gravedad1;
    // Use this for initialization
    void Start () {
        //contador.b_instanciar = 0;
       
	}
	
	// Update is called once per frame
	void Update () {
        gravedad1 = gravedad1;
        if (contador.b_instanciar == 1) {
            //  gravedad = new Vector3(0, 2, 0);
            //Debug.Log(gravedad1);
            FalconUnity.applyForce(0, -gravedad1, 0.2f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("colision");

        if (collision.gameObject.tag == "base")
        {
           // Debug.Log("hola");
            if (contador.b_instanciar == 0)
            {
                
                Crear();
               // gravedad = new Vector3(0, 2, 0);
                gravedad1 = new Vector3(0, Random.Range(0,5), 0);
                //Debug.Log(gravedad);

            }
        }
        
    }

    private void Crear()
    {
        aux =  Random.Range(1,10);
         if (aux < 3)
         {
             aux = 1;
         }
         else
         {
             if (aux < 5)
             {
                 aux = 2;
             }
             else { aux = 3; }
         }



        while (forma == aux)
        {
            aux = Random.Range(1, 3);
        }
       
        Debug.Log(aux);
        forma = aux;
        //forma = 1;
        if (forma == 1)
        {
            Debug.Log("cubo");
            //GetComponent<Transform>().localScale =new Vector3(5f,5f, 5f);
            hapticTip.transform.localScale = new Vector3(5f, 5f, 5f);
           god.transform.localScale = new Vector3(5f, 5f, 5f);
            GameObject nuevo = Instantiate(cubo, GetComponent<Transform>().position, cubo.transform.rotation);
            nuevo.transform.localScale = new Vector3(5f, 5f, 5f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

        }
        if (forma == 2)
        {
            Debug.Log("cilindro");
           // GetComponent<Transform>().localScale = new Vector3(5.2f,5.2f,5.2f);
            hapticTip.transform.localScale = new Vector3(5.2f,5.2f,5.2f);
            god.transform.localScale = new Vector3(5.2f, 5.2f, 5.2f);
            GameObject nuevo = Instantiate(cilindro, GetComponent<Transform>().position, cilindro.transform.rotation);
            nuevo.transform.localScale = new Vector3(5.2f, 2.8f, 5.2f);// GetComponent<Transform>().localScale;
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

        }
        if (forma == 3)
        {
            Debug.Log("octa");
            //GetComponent<Transform>().localScale = new Vector3(4.8f, 4.8f, 4.8f);
            hapticTip.transform.localScale = new Vector3(4.8f, 4.8f, 4.8f);
            god.transform.localScale = new Vector3(4.8f, 4.8f, 4.8f);
            GameObject nuevo = Instantiate(octa, GetComponent<Transform>().position, octa.transform.rotation);
            nuevo.transform.localScale = new Vector3(4.8f, 4.8f, 4.8f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);

        }
        
       
        contador.b_instanciar = 1;
    }
}
