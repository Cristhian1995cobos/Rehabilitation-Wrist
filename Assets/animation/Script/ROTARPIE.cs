using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTARPIE : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1.5f, 0 ));
    }

}
