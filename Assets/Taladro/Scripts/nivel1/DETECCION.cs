using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DETECCION : MonoBehaviour {
    public int aux = 0;
    public int aux2 = 0;
    public int errores = 0;
    public float indice = 0;
    private AudioSource source;
    public AudioClip taladro;
   
    public Slider slider;
    public Vector3 gravedad;





    // Use this for initialization
    void Start () {
        aux = 0;
        aux2 = 0;
        contador.bandera = 0;
        contador.taladro = 0;
        source = GetComponent<AudioSource>();
        slider.value = contador.peso_taladro;

    }
	
	// Update is called once per frame
	void Update () {

        contador.peso_taladro = slider.value;
        gravedad = new Vector3(0, -slider.value, 0);
        FalconUnity.applyForce(0, gravedad, 0.2f);

        if (GetComponent<Transform>().position.z < -2)
        {
             Debug.Log("ALEJE");
            aux = 0;
            if (aux2 == 1) { 
        GameObject.FindWithTag("llegada1").SetActive(false);
                aux2 = 0;
                contador.bandera = 1;
            }

        }
        contador.taladro = aux;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("entro taladro");
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "llegada2")
        {
            aux = 1;
             Debug.Log("entro taladro");

        }
        if (collision.gameObject.tag == "piezas")
        {
            aux = 1;
            aux2 = 1;
            source.PlayOneShot(taladro, 1F);
            contador.bandera = 0;


        }

        if (collision.gameObject.tag == "llegada")
        {
            
            if (aux == 0)
            {
                errores = errores + 1;
                indice = errores/ 10f;
                contador.error_taladro = indice;
              //  Debug.Log(indice);
            }
            
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("entro taladro");
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "llegada2")
        {
            aux = 1;
            Debug.Log("entro taladro");

        }

        if (collision.gameObject.tag == "piezas")
        {
            aux = 1;
            aux2 = 1;
            source.PlayOneShot(taladro, 1F);
            contador.bandera = 0;


        }

        if (collision.gameObject.tag == "llegada")
        {

            if (aux == 0)
            {
                errores = errores + 1;
                indice = errores / 10f;
                contador.error_taladro = indice;
                //  Debug.Log(indice);
            }

        }


    }


}
