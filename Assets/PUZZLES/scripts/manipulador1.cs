using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manipulador1 : MonoBehaviour
{



    public int falcon_num = 0;
    public bool[] button_states = new bool[4];
    bool[] curr_buttons = new bool[4];
 

    public Transform hapticTip;
    public Transform godObject;
    public Transform manito;
    public float godObjectMass;

   

    private float minDistToMaxForce = 0.0005f;
    private float maxDistToMaxForce = 0.009f;
    public float hapticTipToWorldScale;

    private float savedHapticTipToWorldScale;

    public bool useMotionCompensator;

    private bool haveReceivedTipPosition = false;
    private int receivedCount = 0;
    private int num_falcons;

    // Use this for initialization
    void Start()
    {

        

        contador.pieza = 0;
        contador.piezaagarrada = 0;
        contador.piezasbuenas = 0;
        contador.piezasmalas = 0;
        contador.cronometro = 0;
        contador.ganador = 0;
        contador.errores = 0;
        contador.modo = 0;
        contador.fuerza = 0;

        savedHapticTipToWorldScale = hapticTipToWorldScale;

        FalconUnity.setForceField(falcon_num, new Vector3(0, 0, -10));
        Vector3 tipPositionScale = new Vector3(1, 1, -1);
        tipPositionScale *= hapticTipToWorldScale;

        FalconUnity.updateHapticTransform(falcon_num, transform.position, transform.rotation, tipPositionScale, useMotionCompensator, 1 / 60.0f);

        godObjectMass = 0.0001f;
        FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
        num_falcons = FalconUnity.getNumFalcons();
        FalconUnity.Update();

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
            manito.position = posGod;
            
            godObject.rotation = new Quaternion(0, 0, 0, 1);

            //	FalconUnity.setForceField(falcon_num,force);

        }
        else
        {
            Debug.Log("notomaposicion");
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
               
                if (contador.pieza == 0)
                {
                    contador.pieza = 1;
                    manito.GetComponent<Renderer>().enabled = true;
                    godObject.GetComponent<Renderer>().enabled = false;
                  
                }
                else { contador.pieza = 0;
       
                    manito.GetComponent<Renderer>().enabled = false;
                    godObject.GetComponent<Renderer>().enabled = true;
                    
                }
                Debug.Log(contador.pieza);

                break;
            case 2:

                break;
            case 3:
                break;

        }
    }

}
