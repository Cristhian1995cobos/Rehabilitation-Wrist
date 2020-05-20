using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciar3 : MonoBehaviour
{
    public GameObject hapticTip;
    public GameObject god;
    public GameObject cubo;
    public GameObject cilindro;
    public GameObject octa;

   
    private int forma;
    private int aux;

    private Vector3 gravedad = new Vector3(0, 0, 0);
    static Vector3 gravedad1;
    // Use this for initialization
    void Start()
    {
        contador.b_instanciar = 0;
        contador.saber = 0;
        aux = 0;
    }

    // Update is called once per frame
    void Update()
    {

        gravedad1 = gravedad1;
        if (contador.b_instanciar == 1)
        {
            //  gravedad = new Vector3(0, 2, 0);
            //Debug.Log(gravedad1);
            FalconUnity.applyForce(0, -gravedad1, 0.2f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("colision");

        if (collision.gameObject.tag == "cubo" )
        {
            // Debug.Log("hola");
            if (contador.b_instanciar == 0)
            {
              
                Crear();
                // gravedad = new Vector3(0, 2, 0);
                gravedad1 = new Vector3(0, Random.Range(1, 3), 0);
                //Debug.Log(gravedad);

            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
       // Debug.Log("colision");

        if (collision.gameObject.tag == "base")
        {
            // Debug.Log("hola");
            if (contador.b_instanciar == 0)
            {

                Crear();
                // gravedad = new Vector3(0, 2, 0);
                gravedad1 = new Vector3(0, Random.Range(1, 4), 0);
                //Debug.Log(gravedad);

            }
        }

    }


    private void Crear()
    {
        aux = Random.Range(1, 37);
        if (aux < 10)
        {
            aux = 1;
        }
        else
        {
            if (aux < 20)
            {
                aux = 2;
            }
            else
            {
               aux = 3;
             }

         }

        while (forma == aux)
        {
            aux = Random.Range(1, 3);

        }
        forma = aux;
        contador.saber = 1;
        Debug.Log("saber " + contador.saber);
      //  forma = 1;
        if (forma == 1)
        {
            Debug.Log("cubo_grande");
           // GetComponent<Transform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
            hapticTip.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            god.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            GameObject nuevo = Instantiate(cubo, hapticTip.GetComponent<Transform>().position, cubo.transform.rotation);
            nuevo.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            // nuevo.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1.0f);

        }
        if (forma == 2)
        {
            Debug.Log("cilindro_grande");
            //GetComponent<Transform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
            hapticTip.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            god.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            GameObject nuevo = Instantiate(cilindro, hapticTip.GetComponent<Transform>().position, cilindro.transform.rotation);
           nuevo.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            //nuevo.GetComponent<Renderer>().material.color = new Color(0, 34, 255, 1.0f);

        }
        if (forma == 3)
        {
            Debug.Log("octa_grande");
           // GetComponent<Transform>().localScale = new Vector3(1.3f, 1.3f, 1.3f);
            hapticTip.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            god.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            GameObject nuevo = Instantiate(octa, hapticTip.GetComponent<Transform>().position, octa.transform.rotation);
            nuevo.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            // nuevo.GetComponent<Renderer>().material.color = new Color(27, 185, 27, 1.0f);

        }
        
        
        contador.b_instanciar = 1;
        contador.bodynum = 0;

    }
}
