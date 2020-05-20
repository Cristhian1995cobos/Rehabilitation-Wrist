using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detectarniv3 : MonoBehaviour
{
   
    public AudioClip creacion;
    public AudioClip error;
    private int aux=0;
    private AudioSource source;
    private int bandera = 0;
    private int rigid = 0;
  //  public GameObject donita1;
  
    // Use this for initialization
    void Start()
    {
        contador.bodynum = 0;
        source = GetComponent<AudioSource>();
        contador.borrar = 0;
        source.PlayOneShot(creacion, 1F);
        aux = 0;
        bandera = 0;
        contador.primer = 0;
        contador.mensaje = 0;
        rigid = 0;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador.saber == 0)
        {
            if (rigid == 0)
            {
              //  gameObject.AddComponent<Rigidbody>();
               // gameObject.AddComponent<Rigidbody>().useGravity = false;


                rigid = 1;
            }
        }
        else {
            
            bandera = 0;
            contador.primer = 0;
        }
        
        if (contador.mensaje == 1)
        {
            if (GetComponent<Transform>().position.y > 3.9)
            {
                contador.mensaje = 0;
                Debug.Log("mensajito");
            }
        }
        /*   if (aux > 10000)
           {
               contador.borrar = 1;
           }*/

      
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("colision");

        if (collision.gameObject.tag == "referencia"&& contador.saber == 0)
        {

            //Debug.Log("crferencia");
            bandera = 1;
            contador.primer = 1;
        }
        if (collision.gameObject.tag == "paredes" && contador.saber == 0)
        {
            
            contador.fallos = contador.fallos + 1;
            Debug.Log("fallos" + contador.fallos);
            contador.b_instanciar = 0;
            contador.bodynum = 1;
            
            contador.borrar = 1;
        }


        if (collision.gameObject.tag == gameObject.tag)
        {
           // Debug.Log("colision1");
            if (contador.saber == 0 && bandera==1)
            {

               // Debug.Log("colision2");

                if (contador.b_instanciar == 1)
            {
                   
                    contador.acierto = contador.acierto + 1;
                Debug.Log("aciertos" + contador.acierto);
                    
                    contador.borrar = 1;
                    
                }
            contador.b_instanciar = 0;

            contador.bodynum = 1;
            }


        }

    }


    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("colision");

        if (collision.gameObject.tag == "referencia" && contador.saber == 0)
        {

            //Debug.Log("crferencia");
            bandera = 1;
            contador.primer = 1;
        }

        if (collision.gameObject.tag == "referencia" && contador.saber == 1)
        {
            contador.mensaje = 1;
            Debug.Log("mensaje" + contador.mensaje);
        }
      

    }

   

}
