using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manipuladortaladro2 : MonoBehaviour
{



    public int falcon_num = 0;
    public bool[] button_states = new bool[4];
    bool[] curr_buttons = new bool[4];


    public Transform hapticTip;
    public Transform godObject;
    public Transform camara;
      

    public float godObjectMass;



    private float minDistToMaxForce = 0.0005f;
    private float maxDistToMaxForce = 0.009f;
    public float hapticTipToWorldScale;

    private float savedHapticTipToWorldScale;

    public bool useMotionCompensator;

    private bool haveReceivedTipPosition = false;
    private int receivedCount = 0;
    private int num_falcons;
    private int aux = 0;
    public Vector3 broca1;
    public Vector3 broca2;


    // Use this for initialization
    void Start()
    {

        //FalconUnity.setForceField(falcon_num, new Vector3(0, 0, -20));

       
        contador.taladro = 0;
        contador.aciertos = 0;
        contador.error_taladro = 0;
        contador.cronometro = 0;
        contador.ganador = 0;
        contador.errores = 0;
        contador.modo = 0;
        contador.fuerza = 0;
        contador.ganador_taladro = 1;
        contador.pieza = 0;


        aux = 1;

        savedHapticTipToWorldScale = hapticTipToWorldScale;

        // FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
        Vector3 tipPositionScale = new Vector3(1, 1, -1);
        tipPositionScale *= hapticTipToWorldScale;

        FalconUnity.updateHapticTransform(falcon_num, transform.position, transform.rotation, tipPositionScale, useMotionCompensator, 1 / 60.0f);

        godObjectMass = 0.0001f;
        //  FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (aux == 0)
        {
            FalconUnity.setSphereGodObject(falcon_num, godObject.localScale.x * godObject.GetComponent<SphereCollider>().radius, godObjectMass, godObject.position, minDistToMaxForce * hapticTipToWorldScale, maxDistToMaxForce * hapticTipToWorldScale);
            aux = 1;
        }
        

        num_falcons = FalconUnity.getNumFalcons();
        FalconUnity.Update();




        if (contador.ganador_taladro == 0)
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
                hapticTip.position = new Vector3(posTip2.x, posTip2.y, posTip2.z);//posTip2.z

                godObject.position = new Vector3(posTip2.x, posTip2.y, posTip2.z);

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
            hapticTip.position = posTip;

            godObject.position = posGod;
            // manito.position = posGod;

            godObject.rotation = new Quaternion(0, 0, 0, 1);

            camara.position = godObject.position;

            
        }
        else { }





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

               // Debug.Log(contador.bloqueo);

                if (contador.bloqueo == 0)
                {
                    aux = 0;
                   // Debug.Log(contador.broca + "broca");
                    if (contador.broca == 0)
                    {

                        //godObject.GetComponent<Transform>().localScale = new Vector3(3f, 3f, 3f);
                        //hapticTip.GetComponent<Transform>().localScale = new Vector3(3f, 3f, 3f);
                        godObject.GetComponent<Transform>().localScale = broca2;
                        hapticTip.GetComponent<Transform>().localScale = broca2;

                        contador.broca = 1;
                    }
                    else
                    {
                        // godObject.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                        // hapticTip.GetComponent<Transform>().localScale = new Vector3(2f, 2f, 2f);
                        godObject.GetComponent<Transform>().localScale = broca1;
                        hapticTip.GetComponent<Transform>().localScale = broca1;
                        contador.broca = 0;
                    }
                }
                

                break;
            case 2:

                break;
            case 3:
                break;

        }
    }

}
