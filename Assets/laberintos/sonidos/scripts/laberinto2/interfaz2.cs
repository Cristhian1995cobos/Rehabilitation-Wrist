using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interfaz2 : MonoBehaviour {

    public Text textchoques;
    public Text cronometro;
    public Text tiempo;
    public Text indicador;
    public RawImage great;
    public RawImage bien;
    public RawImage malo;
    public RawImage buen;
    public RawImage normal;
    public RawImage mal;
    public int falcon_num = 0;
    public Vector3 constantforce2;
    private int solo = 0;


    public Button seguir;
    private float timer = 0.0f;
    private float waitTime = 1.0f;


    public float time = 0;
    public GameObject mensaje;
    public float indice;
    public int aux;
    public int aux2;


    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        waitTime = 300f;
        seguir.enabled = false;
        great.enabled = false;
        bien.enabled = false;
        malo.enabled = false;
        buen.enabled = false;
        normal.enabled = false;
        mal.enabled = false;
        aux = 0;
        aux2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (aux == 0)
        {
            indice = contador2.numero_choques / 10f;
        }

        textchoques.text = "Indice de fallos: " + indice;
        if (aux2 < 10000)
        {

            if (contador2.fuerza == 1)
            {
                timer = timer + 1.0f;
                if (timer > waitTime)
                {
                    seguir.enabled = true;
                }

                FalconUnity.setForceField(falcon_num, constantforce2);

            }

            if (contador2.numero_llegada == 1)
            {

                contador2.fuerza = 1;
                aux = 1;
                mensaje.transform.localPosition = new Vector3(0, 0, 0);
                Destroy(cronometro);
                Destroy(textchoques);
                contador2.cronometro = 0;

                if (time > 40)
                {
                    malo.enabled = true;
                }
                else
                {
                    if (time > 20)
                    {
                        bien.enabled = true;
                    }
                    else
                    {
                        great.enabled = true;
                    }
                }

                if (indice > 10)
                {
                    mal.enabled = true;
                }
                else
                {
                    if (indice > 5)
                    {
                        normal.enabled = true;
                        mal.enabled = true;
                    }
                    else
                    {
                        buen.enabled = true;
                        normal.enabled = true;
                        mal.enabled = true;
                    }
                }





            }
            aux2 = aux2 + 1;
            Debug.Log("entre");
        }

        if (contador2.cronometro == 1)
        {
            time += Time.deltaTime;
           
            
        }
        cronometro.text = "Tiempo: " + time;//.ToString("f0");
        tiempo.text = "Tu tiempo fue de : " + time + " seg.";
        indicador.text = "Tu indice fue : " + indice;

    }

    public void Click()
    {
        Debug.Log("finalizo");
       // SceneManager.LoadScene("laberintonivel1sinregistro");
    }

}
