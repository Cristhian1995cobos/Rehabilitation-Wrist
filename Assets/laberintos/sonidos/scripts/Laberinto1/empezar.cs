using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empezar : MonoBehaviour
{
    public int aux;
    public int aux2;
    public int auxllegada2;
    public int auxllegada;
    public int auxsonido;
    public int score;
    public int llegar;
    public AudioClip choque;
    public AudioClip pasado;
    
   

    private float timer = 0.0f;
    private float waitTime = 1.0f;

    private AudioSource source;

    public GameObject esfera;
    Vector3 pos;//posicion actual
    Vector3 posa;//posicion anterior
    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        waitTime = 0.5f;
        source = GetComponent<AudioSource>();
        score = 0;
        llegar = 0;
        aux = 0;
        aux2 = 0;
        auxllegada = 1;
        auxllegada2 = 1;
        auxsonido = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       // bool[] botones;
       // FalconUnity.getFalconButtonStates(0, out botones);
        if (contador.ini == 1)
        {
            aux2 = 1;
          //  Debug.Log("boton2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("colli");

        if (aux2 == 1)
        {

            pos = new Vector3(esfera.transform.localPosition.x, esfera.transform.localPosition.y, 0);

            if (collision.gameObject.tag == "paredes")
            {



                if (contador.cronometro == 1)
                {
                    score = score + 1;
                }

                    if (timer > waitTime && auxsonido == 0)
                    {
                        source.PlayOneShot(choque, 1F);
                        timer = 0;
                    }


               

            }
            contador.numero_choques = score;
            posa = pos;

       


         if (auxllegada2 == 1)
            {

                if (collision.gameObject.tag == "llegada")
                {
                    llegar = 1;
                    if (auxsonido == 0)
                    {
                        source.PlayOneShot(pasado, 1F);
                        auxsonido = 1;
                    }
                }
            }
            contador.numero_llegada = llegar;



        }

    }


}