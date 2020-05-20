using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class empezarpuzzle : MonoBehaviour
{

    public int aux = 0;
    public GameObject esfera;
    public string pieza = "";
    public string referencia = "";
    public string prueba = "";
    private int buenas;
    private int malas;
    private Renderer figura;
    private Renderer refe;

    private AudioSource source;
    public AudioClip pimalas;
    public AudioClip pibuenas;

    private Renderer puzzle2;
    private Renderer puzzle3;
    public GameObject manito;
    private GameObject p1;
    private GameObject r1;
    public Vector3 gravedad;
    private GameObject base1;
    public Slider slider;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        slider.value = - contador.peso;
        aux = 0;
        pieza = "";
        referencia = "";
        prueba = "";
        figura = esfera.GetComponent<Renderer>();
        base1 = GameObject.Find("puzzle1ref");
        buenas = 0;
        malas = 0; 

        r1 = GameObject.Find("1 (1)");
        refe = r1.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()

    {
        contador.peso = - slider.value;
        //Debug.Log(contador.peso);
        gravedad = new Vector3(0, contador.peso, 0);

        if (contador.pieza == 1)
        {
            if (aux == 1)
            {

                p1.gameObject.transform.position = new Vector3(esfera.transform.localPosition.x, esfera.transform.localPosition.y, esfera.transform.localPosition.z);

                FalconUnity.applyForce(0, gravedad, 0.2f);

            }
        }
        else
        {

            if (aux == 1)
            {


                Behaviour halo = (Behaviour)p1.GetComponent("Halo");
                halo.enabled = false;

                figura.enabled = true;
                aux = 0;
                prueba = "" + pieza + " (1)";
                
                if (prueba == referencia)
                {
                    r1 = GameObject.Find(referencia);
                    p1.gameObject.transform.position = r1.gameObject.transform.position;
                    Debug.Log("bien");
                    buenas++;
                    contador.piezasbuenas = buenas;
                    source.PlayOneShot(pibuenas,1F);

                }
                else
                {
                    Debug.Log("mal");
                    malas++;
                    contador.piezasmalas = malas;
                    contador.errores = malas;
                    source.PlayOneShot(pimalas,1F);

                }

            }

        }
        contador.piezaagarrada = aux;

    }




    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(contador.pieza);
        if (collision.gameObject.tag == "piezas")
        {

            if (contador.pieza == 1)
            {
                if (aux == 0)
                {


                    aux = 1;
                    pieza = collision.gameObject.name;
                    p1 = GameObject.Find(pieza);
                    Behaviour halo = (Behaviour)p1.GetComponent("Halo");
                    halo.enabled = true;
                    manito.GetComponent<Renderer>().enabled = false;
                    figura.enabled = false;
                    //  Debug.Log("entre");
                }

            }

        }

        if (collision.gameObject.tag == "referencia")
        {
            
            if (contador.piezaagarrada == 1)
            {
                refe.enabled = false;
                referencia = collision.gameObject.name;
                r1 = GameObject.Find(referencia);

                refe = r1.GetComponent<Renderer>();
                refe.enabled = true;

              

            }


        }



    }
    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log(contador.pieza);
        if (collision.gameObject.tag == "piezas")
        {

            if (contador.pieza == 1)
            {
                if (aux == 0)
                {


                    aux = 1;
                    pieza = collision.gameObject.name;
                    p1 = GameObject.Find(pieza);
                    Behaviour halo = (Behaviour)p1.GetComponent("Halo");
                    halo.enabled = true;
                    manito.GetComponent<Renderer>().enabled = false;
                    figura.enabled = false;
                    //  Debug.Log("entre");
                }

            }

        }

        if (collision.gameObject.tag == "referencia")
        {

            if (contador.piezaagarrada == 1)
            {
                refe.enabled = false;
                referencia = collision.gameObject.name;
                r1 = GameObject.Find(referencia);

                refe = r1.GetComponent<Renderer>();
                refe.enabled = true;



            }


        }



    }

}
