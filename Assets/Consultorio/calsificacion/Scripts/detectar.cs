using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectar : MonoBehaviour {
    public AudioClip bien;
    private bool[] botones;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        contador.bodynum = 0;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(bien, 1F);
    }
	
	// Update is called once per frame
	void Update () {

        FalconUnity.getFalconButtonStates(0,out botones);
        if (botones[1] == true)
        {
            contador.b_instanciar = 0;
            contador.bodynum = 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {


        Debug.Log("colision");
        if (collision.gameObject.tag == gameObject.tag)
        {
            
           
            if (contador.b_instanciar == 1)
            {
                contador.acierto = contador.acierto + 1;
                Debug.Log("aciertos" + contador.acierto);
                
            }
            contador.b_instanciar = 0;
            
                contador.bodynum = 1;
            


        }
        if (collision.gameObject.tag == "verde1")
        {


           
            contador.b_instanciar = 0;
            contador.bodynum = 1;



        }

    }
}
