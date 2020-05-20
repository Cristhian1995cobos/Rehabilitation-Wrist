using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotar : MonoBehaviour {
    public RawImage objeto;
    public float aux = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        aux = aux + 0.01f;
        transform.Rotate (new Vector3(5,0,0));
	}
    
}
