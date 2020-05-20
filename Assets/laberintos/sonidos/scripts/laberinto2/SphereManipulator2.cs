using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereManipulator2 : MonoBehaviour {


    public int aux = 1;
    public int aux2 = 0;
    public int iniciar = 0;
    public int empezar = 0;


    private Scene m_Scene;
    public Camera peque;
    public RawImage cuadro;
    public int falcon_num = 0;
    public bool[] button_states = new bool[4];
    bool[] curr_buttons = new bool[4];
    public Vector3 constantforce;
    public Vector3 constantforce2;

    public Transform hapticTip;
    public Transform godObject;
    public float godObjectMass;

    public GameObject techo;
    public GameObject texto1;
    public GameObject refentrada;
    public GameObject warming;
    public GameObject permiti;
    public RawImage INICIO;
    private int solo = 0;
    private float time = 0;

    private float minDistToMaxForce = 0.0005f;
    private float maxDistToMaxForce = 0.009f;
    public float hapticTipToWorldScale;

    private float savedHapticTipToWorldScale;

    public bool useMotionCompensator;

    private bool haveReceivedTipPosition = false;
    private int receivedCount = 0;
    public int aux_puerta = 0;
    private int num_falcons;

    // Use this for initialization
    void Start()
    {
        empezar = 0;
        iniciar = 0;
        FalconUnity.setForceField(falcon_num, new Vector3(0, 0, -25));
        INICIO.enabled = true;

        contador.cronometro = 0;
        contador.fuerza = 0;
        contador.numero_choques = 0;
        contador.numero_llegada = 0;
        aux = 0;
        aux2 = 0;
        aux_puerta = 0;
        savedHapticTipToWorldScale = hapticTipToWorldScale;

        //FalconUnity.setForceField(falcon_num, constantforce);
        Vector3 tipPositionScale = new Vector3(1, 1, -1);
        tipPositionScale *= hapticTipToWorldScale;

        FalconUnity.updateHapticTransform(falcon_num, transform.position, transform.rotation, tipPositionScale, useMotionCompensator, 1 / 60.0f);

        godObjectMass = 0.0001f;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (empezar == 0)
        {
            Debug.Log(iniciar);
            iniciar = iniciar + 1;
            if (iniciar < 50)
            {
                FalconUnity.setForceField(falcon_num, constantforce2);

            }
            else
            {
                FalconUnity.setForceField(falcon_num, constantforce);   

            }
        }

        num_falcons = FalconUnity.getNumFalcons();
        FalconUnity.Update();

        if (aux2 == 1)
        {
            FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
            Vector3 pos;
            bool p = FalconUnity.getTipPosition(falcon_num, out pos);
            if (contador.puerta == 1)
            {
                contador.puerta = 0;
                contador.cronometro = 1;
                aux2 = 0;
                INICIO.enabled = false;
            }
        }
        
        if (contador.fuerza == 0)
        {
            if (!haveReceivedTipPosition)
            {
                Vector3 posTip2;
                bool result = FalconUnity.getTipPosition(falcon_num, out posTip2);
                if (!result)
                {
                    //				Debug.Log("Error getting tip position");
                    return;
                }
                receivedCount++;

                if (receivedCount < 25 && (posTip2.x == 0 && posTip2.y == 0 && posTip2.z == 0))
                {
                    return;
                }

                //hapticTip.position = posTip2;

                //godObject.position = posTip2;
                hapticTip.position = new Vector3(posTip2.x, posTip2.y, 0.45f);//posTip2.z

                godObject.position = new Vector3(posTip2.x, posTip2.y, 0.45f);

                Debug.Log("Initialized with tip position: ");
                Debug.Log(posTip2);
                FalconUnity.setSphereGodObject(falcon_num, godObject.localScale.x * godObject.GetComponent<SphereCollider>().radius, godObjectMass, godObject.position, minDistToMaxForce * hapticTipToWorldScale, maxDistToMaxForce * hapticTipToWorldScale);

                haveReceivedTipPosition = true;
            }

            Vector3 tipPositionScale = new Vector3(1, 1, -1);
            tipPositionScale *= hapticTipToWorldScale;

            if (savedHapticTipToWorldScale != hapticTipToWorldScale)
            {
                FalconUnity.setSphereGodObject(falcon_num, godObject.localScale.x * godObject.GetComponent<SphereCollider>().radius, godObjectMass, godObject.position, minDistToMaxForce * hapticTipToWorldScale, maxDistToMaxForce * hapticTipToWorldScale);
                savedHapticTipToWorldScale = hapticTipToWorldScale;

            }

            FalconUnity.updateHapticTransform(falcon_num, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation, tipPositionScale, useMotionCompensator, Time.deltaTime);

            Vector3 posGod;
            bool res = FalconUnity.getGodPosition(falcon_num, out posGod);
            if (!res)
            {
                //			Debug.Log("Error getting god tip position");
                return;
            }
            Vector3 posTip;
            res = FalconUnity.getTipPosition(falcon_num, out posTip);
            if (!res)
            {
                //			Debug.Log("Error getting tip position");
                return;
            }
            //hapticTip.position = posTip;

            //godObject.position = posGod;
            hapticTip.position = new Vector3(posTip.x, posTip.y, 0.45f);

            godObject.position = new Vector3(posGod.x, posGod.y, 0.45f);
            godObject.rotation = new Quaternion(0, 0, 0, 1);

            //	FalconUnity.setForceField(falcon_num,force);
            if (time > 2.5 && solo == 0)
            {

                permiti.transform.localPosition = warming.transform.localPosition;
                warming.transform.localPosition = new Vector3(1000, 1000, 1000);
                solo = 1;


            }
        }
        else
        {
            Debug.Log("notomaposicion");
            peque.enabled = false;
            cuadro.enabled = false;
        }
    }

    void OnApplicationQuit()
    {
        FalconUnity.Stop();
        FalconUnity.disconnect();
        Debug.Log("salida");

    }


    void LateUpdate()
    {


        bool res = FalconUnity.getFalconButtonStates(falcon_num, out curr_buttons);


        if (!res)
        {
            //			Debug.Log("Error getting button states");
            return;
        }
        //go through the buttons, seeing which are pressed
        for (int i = 0; i < 4; i++)
        {
            if (button_states[i] && button_states[i] != curr_buttons[i])
            {
                buttonPressed(i);
            }

            button_states[i] = curr_buttons[i];
        }


    }


    void buttonPressed(int i)
    {

        switch (i)
        {
            case 0:

                break;
            case 1:
                if (aux_puerta == 0)
                {
                    empezar = 1;
                    Instantiate(techo, new Vector3(0f, 1.37f, 0.20f), transform.rotation);
                    FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
                    peque.enabled = true;
                    cuadro.enabled = true;
                    Destroy(texto1);
                    aux_puerta = 1;
                    contador.ini = 1;
                }


                aux2 = 1;
                break;
            case 2:

                break;
            case 3:
                break;

        }
    }

}
