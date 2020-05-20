using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrir_server : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        if (info.servidor == 0)
        {
            System.Diagnostics.Process.Start(Application.dataPath + "/Plugins/FalconServer.exe");
            info.servidor = 1;
        }
    }
    void Start () {
        info.juego = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
