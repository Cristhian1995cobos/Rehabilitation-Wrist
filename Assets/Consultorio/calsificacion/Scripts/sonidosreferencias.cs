using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sonidosreferencias : MonoBehaviour {
    public AudioClip bien;
   
    private AudioSource source;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        //source.PlayOneShot(agarrado, 1F);
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {

        //source.PlayOneShot(bien, 1F);
        if (collision.gameObject.tag == gameObject.tag)
        {
            source.PlayOneShot(bien, 1F);

        }

    }
}
