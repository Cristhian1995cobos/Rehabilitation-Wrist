using UnityEngine;
using System.Collections;
using System.Text;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class FalconMain2 : MonoBehaviour
{
    public int num_falcons;
    public int my_num;
    private static int my_num_falcons;
    public Vector3 gravity;
    private int cont = 0;
    public string address;
    public int port;
    public AddressFamily protocol;
    private Scene m_Scene;

    // Use this for initialization
    void Awake()
    {
       
            my_num = getNextNum1();

            if (my_num == 0)
            {

                //     Debug.Log(address + " " + port + " " + protocol);
                //     FalconUnity.setServerParams(address, port, protocol);

            }
       
            FalconUnity.Start();

    }
   
    void OnApplicationQuit()
    {
        if (my_num == 0)
        {
          // FalconUnity.Stop();
          // FalconUnity.disconnect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (my_num == 0)
        {
            num_falcons = FalconUnity.getNumFalcons();
            FalconUnity.Update();
        }
    }

    void Start()
    {
        /*
        //		FalconUnity.setForceField(0, new float[] {0,-10,0});
        if (my_num == 0)
        {
            num_falcons = FalconUnity.getNumFalcons();
            if (FalconUnity.IsRemote())
            {
                FalconUnity.Update();
            }
        }*/
    }


    static object Lock = new object();
    private static int curId = -1;
    public static int getNextNum()
    {
        lock (Lock)
        {
            curId++;
            return curId;
        }
    }
    static object Lock1 = new object();
    private static int curId1 = -1;
    public static int getNextNum1()
    {
        lock (Lock1)
        {
            curId1++;
            return curId1;
        }
    }
}