using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choquesss : MonoBehaviour {
    public int aux = 0;
    public int aux2;
    public GameObject verde;
    public GameObject rojo;
    public GameObject madera;
    public AudioClip bien;
    private AudioSource source;
    public GameObject aserrin;
    public RawImage medalla;
   
    // Use this for initialization
    void Start () {
        aux = 0;
        aux2 = 0;
        rojo.SetActive(true);
        verde.SetActive(false);
        madera.SetActive(true);
        source = GetComponent<AudioSource>();
        aserrin.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
      //  FalconUnity.applyForce(0, new Vector3(0, 0, 0), 0.2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("colision");

        if (collision.gameObject.tag == "paredes")
        {
            //Debug.Log("hola");
            if (aux2 ==0)
            {
                aux2 = 1;
                //   Debug.Log("entro");
                contador.aciertos = contador.aciertos + 1;
                Debug.Log(contador.aciertos);
                medalla.GetComponent<RawImage>().enabled = false;
                rojo.SetActive(false);
                verde.SetActive(true);
                aserrin.SetActive(false);
                madera.SetActive(false);
                aux = aux + 1;
                
                source.PlayOneShot(bien, 1F);
               

            }
        }
        else
        {
            aserrin.SetActive(true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
       // Debug.Log("colision");

        if (collision.gameObject.tag == "paredes")
        {
          //  Debug.Log("hola");
            if (aux2 == 0)
            {
                aux2 = 1;
                Debug.Log("entro");
               // contador.aciertos =contador.aciertos+1 ;
                rojo.SetActive(false);
                aserrin.SetActive(false);
                verde.SetActive(true);
                madera.SetActive(false);
                aux = aux + 1;
                
                source.PlayOneShot(bien, 1F);
                

            }


        }
        else
        {
            if (!aserrin.active )
            {
                aserrin.SetActive(true);
            }
        }

    }

}
