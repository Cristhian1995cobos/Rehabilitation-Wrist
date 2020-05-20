using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciar2 : MonoBehaviour {
    public GameObject hapticTip;
    public GameObject god;
    public GameObject cubo;
    public GameObject cilindro;
    public GameObject octa;
   
    public GameObject triangulo;
    public GameObject cubo_peque;
    public GameObject cilindro_peque;
    public GameObject octa_peque;
    public GameObject triangulo_peque;
    private int forma;
    private int aux;
    
    private Vector3 gravedad = new Vector3(0, 0, 0);
    static Vector3 gravedad1;
    // Use this for initialization
    void Start()
    {
        contador.b_instanciar = 0;
      
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

        if (collision.gameObject.tag == "base")
        {
            // Debug.Log("hola");
            if (contador.b_instanciar == 0)
            {
                
                Crear();
                // gravedad = new Vector3(0, 2, 0);
                gravedad1 = new Vector3(0, Random.Range(0, 7), 0);
                //Debug.Log(gravedad);

            }
        }

    }

    private void Crear()
    {
        aux = Random.Range(1, 87);
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
                if (aux < 30)
                {
                    aux = 3;
                }
                else
                {
                    if (aux < 40)
                    {
                        aux = 4;
                    }
                    else
                    {
                        if (aux < 50)
                        {
                            aux = 5;
                        }
                        else
                        {
                            if (aux < 60)
                            {
                                aux = 6;
                            }
                            else
                            {
                                if (aux < 70)
                                {
                                    aux = 7;
                                }
                                else
                                {
                                    aux = 8;
                                }

                            }

                        }

                    }

                }

            }

        }



        while (forma == aux)
        {
            aux = Random.Range(1, 8) ;
            
        }
        forma = aux;


        Debug.Log(forma);
        //forma = 8;
        if (forma == 1)
        {
            Debug.Log("cubo_grande");
          //  GetComponent<Transform>().localScale = new Vector3(7f,7f, 7f);
             hapticTip.transform.localScale = new Vector3(7f, 7f, 7f);
            god.transform.localScale = new Vector3(7f, 7f, 7f);

            GameObject nuevo = Instantiate(cubo, hapticTip.GetComponent<Transform>().position, cubo.transform.rotation);
            nuevo.transform.localScale = new Vector3(7f, 7f, 7f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
           

        }
        if (forma == 2)
        {
            Debug.Log("cilindro_grande");
            //GetComponent<Transform>().localScale = new Vector3(8.2f, 8.2f, 8.2f);
            hapticTip.transform.localScale = new Vector3(8.15f, 8.15f, 8.15f);
            god.transform.localScale = new Vector3(8.15f, 8.15f, 8.15f);
            GameObject nuevo = Instantiate(cilindro, hapticTip.GetComponent<Transform>().position, cilindro.transform.rotation);
            nuevo.transform.localScale = new Vector3(8.2f, 5f, 8.2f); ;// GetComponent<Transform>().localScale;
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
           

        }
        if (forma == 3)
        {
            Debug.Log("octa_grande");
            //GetComponent<Transform>().localScale = new Vector3(7.5f, 7.5f, 7.5f);
            hapticTip.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            god.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            GameObject nuevo = Instantiate(octa, hapticTip.GetComponent<Transform>().position, octa.transform.rotation);
            nuevo.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
           

        }
        if (forma == 4)
        {
            Debug.Log("triangulo_grande");
            // GetComponent<Transform>().localScale = new Vector3(4.7f, 4.7f, 4.7f);
            hapticTip.transform.localScale = new Vector3(4.7f, 4.7f, 4.7f);
            god.transform.localScale = new Vector3(4.7f, 4.7f, 4.7f);
            GameObject nuevo = Instantiate(triangulo, hapticTip.GetComponent<Transform>().position, triangulo.transform.rotation);
            nuevo.transform.localScale = new Vector3(4.8f, 4.8f, 4.8f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
          
        }
        if (forma == 5)
        {
            Debug.Log("cubo_peqe");
            // GetComponent<Transform>().localScale = new Vector3(5.2f, 5.2f, 5.2f);
            hapticTip.transform.localScale = new Vector3(5.2f, 5.2f, 5.2f);
           god.transform.localScale = new Vector3(5.2f, 5.2f, 5.2f);
            GameObject nuevo = Instantiate(cubo_peque, hapticTip.GetComponent<Transform>().position, cubo_peque.transform.rotation);
            nuevo.transform.localScale = new Vector3(5.2f, 5.2f, 5.2f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
          
        }
        if (forma == 6)
        {
            Debug.Log("cilindro_peqe");
            //GetComponent<Transform>().localScale = new Vector3(6.5f, 6.5f, 6.5f);
            hapticTip.transform.localScale = new Vector3(6.5f, 6.5f, 6.5f);
            god.transform.localScale = new Vector3(6.5f, 6.5f, 6.5f);
            GameObject nuevo = Instantiate(cilindro_peque, hapticTip.GetComponent<Transform>().position, cilindro_peque.transform.rotation);
            nuevo.transform.localScale = new Vector3(6.5f, 3.7f, 6.5f);// GetComponent<Transform>().localScale;
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
           
        }
        if (forma == 7)
        {
            Debug.Log("octa_peqe");
           // GetComponent<Transform>().localScale = new Vector3(6f, 6f, 6f);
            hapticTip.transform.localScale = new Vector3(6f, 6f, 6f);
            god.transform.localScale = new Vector3(6f, 6f, 6f);
            GameObject nuevo = Instantiate(octa_peque, hapticTip.GetComponent<Transform>().position, octa_peque.transform.rotation);
            nuevo.transform.localScale = new Vector3(6f, 6f, 6f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            
        }
        if (forma == 8)
        {
            Debug.Log("triangulo_peqe");
            //GetComponent<Transform>().localScale = new Vector3(3.8f, 3.8f, 3.8f);
            god.transform.localScale = new Vector3(3.8f, 3.8f, 3.8f);
            hapticTip.transform.localScale = new Vector3(3.8f, 3.8f, 3.8f);
            
            GameObject nuevo = Instantiate(triangulo_peque, god.GetComponent<Transform>().position, triangulo_peque.transform.rotation);
            nuevo.transform.localScale = new Vector3(3.9f, 3.9f, 3.9f);
            nuevo.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
          
        }



        contador.b_instanciar = 1;
      
    }
}
