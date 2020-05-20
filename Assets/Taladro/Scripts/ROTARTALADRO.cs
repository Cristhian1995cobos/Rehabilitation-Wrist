using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROTARTALADRO : MonoBehaviour
{
    
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (contador.taladro == 1)
        {
            transform.Rotate(new Vector3(0, 0, 30));
        }
    }
   


    }
