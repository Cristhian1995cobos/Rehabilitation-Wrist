using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidosniv3 : MonoBehaviour {
    private int aux = 0;
    private int aux2 = 0;
    public AudioClip bien;
 
    
   
    private AudioSource source1;
    private int auxsonido=0;
    private int aparecer = 0;
    public GameObject donita1;
    private int cont = 0;
    // Use this for initialization
    void Start () {
        auxsonido = 0;
        source1 = GetComponent<AudioSource>();
        aux = 0;
        aux2 = 0;
        aparecer = 0;
        contador.fallos = 0;
        cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
      if (auxsonido == 1)
        {
            cont = cont + 1;
            source1 = GetComponent<AudioSource>();
            source1.PlayOneShot(bien, 1F);
            Debug.Log("entre");
            auxsonido = 0;
           
                Instantiate(donita1, GetComponent<Transform>().position, donita1.transform.rotation);

          
            GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.7f, gameObject.transform.position.z);
            if (cont == 6)
            {
                GameObject[] donas = GameObject.FindGameObjectsWithTag(donita1.tag);
                foreach (GameObject d in donas) 
                Destroy(d);
               
               /* int auxx = 0;
                while(auxx<cont) { 
                Destroy(GameObject.FindWithTag(donita1.tag));
                    auxx = auxx + 1;
                */    

                GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -10.2f, gameObject.transform.position.z);
                cont = 0;
            }
        }
      
	}
         
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == gameObject.tag)
        {
            // Debug.Log("colision1");
            if (contador.saber == 0 &&contador.primer==1)
            {
                auxsonido = 1;

            }


        }

    }
}
