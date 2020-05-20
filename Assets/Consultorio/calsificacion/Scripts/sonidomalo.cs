using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidomalo : MonoBehaviour
{
    private int aux = 0;
    private int aux2 = 0;
    public AudioClip bien;
    private int fallo;



    private AudioSource source1;
    private int auxsonido = 0;
    private int aparecer = 0;
    // Use this for initialization
    void Start()
    {
        auxsonido = 0;
        fallo = contador.fallos;
        source1 = GetComponent<AudioSource>();
        aux = 0;
        aux2 = 0;
        aparecer = 0;
        contador.fallos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (auxsonido == 1)
        {
            source1 = GetComponent<AudioSource>();
            source1.PlayOneShot(bien, 1F);
            Debug.Log("entre");
            auxsonido = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

       if (collision.gameObject.tag == "cubo_peque" || collision.gameObject.tag == "octa_peque" || collision.gameObject.tag == "cilindro_peque" )
            // Debug.Log("colision1");
            if (contador.saber == 0 && contador.fallos!= fallo)
            {
                auxsonido = 1;
            }


        fallo = contador.fallos;
    }
}