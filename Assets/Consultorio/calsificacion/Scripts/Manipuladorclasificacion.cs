using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manipuladorclasificacion : MonoBehaviour
{
    public int falcon_num = 0;
    public bool[] button_states = new bool[4];
    bool[] curr_buttons = new bool[4];


    public Transform hapticTip;
    public Transform godObject;
    public Transform camara;
    public int bodynum;
    public float godObjectMass;

    public Vector3 linearfactor;
    public Vector3 angularfactor;
    public float masa;

    private float minDistToMaxForce = 0.0005f;
    private float maxDistToMaxForce = 0.009f;
    public float hapticTipToWorldScale;

    private float savedHapticTipToWorldScale;

    public bool useMotionCompensator;

    private bool haveReceivedTipPosition = false;
    private int receivedCount = 0;
    private int num_falcons;
    private int aux = 0;
    private int aux1 = 0;
    private int aux2 = 0;
  
    private Scene m_Scene;


    // Use this for initialization
    void Start()
    {
       
        /* FalconUnity.setForceField(0, new Vector3(0, -6, 0));
         int d = 0;
         while (d < 500)
         {
             d++;
             Debug.Log(d);
         }

         m_Scene = SceneManager.GetActiveScene();
         if (m_Scene.name== "consultorioniv1")
         {
             Instantiate(mesa, new Vector3(-4.179646f, -15.7f, 6.1f), Quaternion.Euler(new Vector3(-90, 180, 0)));
             Instantiate(base_niv, new Vector3(9.31f, -10.424f, 7.95f), Quaternion.Euler(new Vector3(90, 180, 0)));
             Instantiate(figuras, new Vector3(-15.04f, -12.16f, 6.87f), Quaternion.Euler(new Vector3(90, 0, 0)));
         }
         if (m_Scene.name == "consultorioniv2")
         {
             Instantiate(mesa, new Vector3(-4.179646f, -15.7f, 6.1f), Quaternion.Euler(new Vector3(-90, 180, 0)));
             Instantiate(base_niv, new Vector3(3.62f, -9.36f, 5.4f), Quaternion.Euler(new Vector3(-90, 0, 0)));
             Instantiate(figuras, new Vector3(3.625f, -13.876f, 5.46f), Quaternion.Euler(new Vector3(90, 0, 0)));
         }*/
        contador.ganador_consultorio = 1;
    
         contador.activacion = false;
     
        aux = 1;

        savedHapticTipToWorldScale = hapticTipToWorldScale;

        // FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
        Vector3 tipPositionScale = new Vector3(1, 1, -1);
        tipPositionScale *= hapticTipToWorldScale;

        FalconUnity.updateHapticTransform(falcon_num, transform.position, transform.rotation, tipPositionScale, useMotionCompensator, 1 / 60.0f);

        godObjectMass = 0.0001f;
        //  FalconUnity.setForceField(falcon_num, new Vector3(0, 0, 0));
        aux2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador.b_instanciar == 0 )
        {
            aux1 = 0;
            
        }
        if (contador.b_instanciar == 0&&aux2==0)
        {
            aux2 = 1;
            FalconUnity.setSphereGodObject(falcon_num, godObject.localScale.x * godObject.GetComponent<SphereCollider>().radius, godObjectMass, godObject.position, minDistToMaxForce * hapticTipToWorldScale, maxDistToMaxForce * hapticTipToWorldScale);
        }


        if (contador.b_instanciar == 1 && aux1==0)
        {
            aux = 0;
            aux2 = 0;
        }
        

        if (aux == 0)
        {

            FalconUnity.setSphereGodObject(falcon_num, godObject.localScale.x * godObject.GetComponent<SphereCollider>().radius, godObjectMass, godObject.position, minDistToMaxForce * hapticTipToWorldScale, maxDistToMaxForce * hapticTipToWorldScale);
            aux = 1;
            aux1 = 1;
            aux2 = 0;
        }


        num_falcons = FalconUnity.getNumFalcons();
        FalconUnity.Update();




        if (contador.ganador_consultorio == 0)
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
                //FalconUnity.updateDynamicShape(contador.cuerpo, 0.001f, 0.01f,godObject.transform.localScale, new Vector3(0, 0, 0), 0.8f);
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

                break;
            case 2:
               
       
                break;
            case 3:
                break;

        }
    }

}