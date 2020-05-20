using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigid_nivel3 : MonoBehaviour {

    public float k = 0.5f;
    private int crear = 0;
    public float mass = 1;
    public Vector3 device_scale = new Vector3(1.0f, 1.0f, 1.0f);//send 1/4 size in the z dimension
    public int bodyId = 0;
    public Vector3 linearFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 angularFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public float friction = 0.8f;
    private int numero;

    public GameObject donita1;



    public GameObject cubo;
   // public GameObject cilindro;
   // public GameObject octa;

    private int suelo;
    private bool removido = false; bool[] botones = new bool[4];
    // Use this for initialization
    void Start()
    {
        bodyId = getNextBodyId();
        
        refreshShape();
        crear = 0;

    }

    public void refreshShape()
    {
        Mesh m = GetComponent<MeshFilter>().mesh;
        Vector3[] v = m.vertices;
        int[] f = m.triangles;
        float[] shape = new float[f.Length * 3];

        for (int i = 0; i < f.Length; i++)
        {
            Vector3 vert = v[f[i]];
            vert.Scale(transform.localScale);
            vert.Scale(device_scale);
            //				vert = transform.localRotation*vert;

            shape[i * 3] = vert.x;
            shape[i * 3 + 1] = vert.y;
            shape[i * 3 + 2] = vert.z;
        }
        Vector3 localPosition = transform.localPosition;
        localPosition.Scale(device_scale);


        FalconUnity.sendDynamicShape(bodyId, shape, f.Length / 3, mass, k, localPosition, transform.localRotation, linearFactors, angularFactors, friction);
    }

    public void Update()
    {
        
        bool res1 = FalconUnity.getFalconButtonStates(0, out botones);
        Vector3 pos;
        Quaternion orient;

        if (contador.bodynum == 0)

        {
            if (gameObject.tag == "cubo_peque" || gameObject.tag == "cilindro_peque" || gameObject.tag == "octa_peque")
            {
                bool res = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
                if (!res)
                {
                    //			Debug.Log("Error getting object pose");
                    return;
                }
                transform.localPosition = pos;
                transform.localRotation = orient;
                FalconUnity.updateDynamicShape(bodyId, mass, k, linearFactors, angularFactors, friction);
                
            }
        }
        if (gameObject.tag == "cubo_peque" || gameObject.tag == "cilindro_peque" || gameObject.tag == "octa_peque")
        {
            if (botones[1] == true)
            {
                if (contador.saber == 1 && contador.mensaje==0)
                {
                    
                    Debug.Log("como lo hace");
                    //FalconUnity.removeDynamicShape(bodyId);

                    bool res4 = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
                    transform.localPosition = pos;
                    transform.localRotation = orient;
                    GameObject nuevo = Instantiate(cubo, new Vector3(pos.x, pos.y - 1.5f, pos.z), cubo.transform.rotation);
                    nuevo.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    // FalconUnity.setDynamicShapePose(bodyId, new Vector3(pos.x, pos.y - 1f, pos.z), orient);
                    // FalconUnity.applyForceToShape(bodyId, new Vector3(0, -23, 0), new Vector3(0, 0, 0));
                    //                GetComponent<Rigidbody>().useGravity = true;
                    //Destroy(gameObject);

                    // Destroy(gameObject);
                    // Instantiate(donita1, new Vector3(pos.x, pos.y - 0.8f, pos.z), orient);
                    // gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
                    contador.saber = 0;
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
            
                }

             }


            // contador.bodynum = 0;
            if (contador.saber == 0)
            {
                FalconUnity.applyForceToShape(bodyId, new Vector3(0, -1.5f, 0), new Vector3(0, 0, 0));
            }
            if (contador.borrar == 1|| contador.ganador_consultorio == 1)
            {

                FalconUnity.removeDynamicShape(bodyId);
                contador.borrar = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            bool res = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
            if (!res)
            {
                //			Debug.Log("Error getting object pose");
                return;
            }
            transform.localPosition = pos;
            transform.localRotation = orient;
            FalconUnity.updateDynamicShape(bodyId, mass, k, linearFactors, angularFactors, friction);
        }




    }
    // Update is called once per frame
    public void FixedUpdate()
    {

        Vector3 pos;
        Quaternion orient;
        //contador.bodynum == 1 || contador.ganador_consultorio == 1 ||
    /*    if (gameObject.tag == "cubo_peque" || gameObject.tag == "cilindro_peque" || gameObject.tag == "octa_peque")
        {
            if (botones[1] == true)
            {
                if (contador.saber == 1)
                {
                    Debug.Log("como lo hace");
                    //FalconUnity.removeDynamicShape(bodyId);
                    bool res4 = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
                    transform.localPosition = pos;
                    transform.localRotation = orient;
                    FalconUnity.setDynamicShapePose(bodyId, new Vector3(pos.x, pos.y -2f, pos.z), orient);
                    //                GetComponent<Rigidbody>().useGravity = true;
                    //Destroy(gameObject);

                    // Destroy(gameObject);
                    // Instantiate(donita1, new Vector3(pos.x, pos.y - 0.8f, pos.z), orient);
                    // gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
                    contador.saber = 0;

                }
            }

            if (contador.borrar == 1)
            {
                FalconUnity.removeDynamicShape(bodyId);
                Destroy(gameObject);
                contador.borrar = 0;
            }
            // contador.bodynum = 0;
        }
        else
        {
            bool res = FalconUnity.getDynamicShapePose(bodyId, out pos, out orient);
            if (!res)
            {
                //			Debug.Log("Error getting object pose");
                return;
            }
            transform.localPosition = pos;
            transform.localRotation = orient;
            FalconUnity.updateDynamicShape(bodyId, mass, k, linearFactors, angularFactors, friction);
        }
        


        if (contador.bodynum == 1 || contador.ganador_consultorio == 1)
        {
            if (gameObject.tag == "cubo_peque" || gameObject.tag == "cilindro_peque" || gameObject.tag == "octa_peque")
            {
                FalconUnity.updateDynamicShape(bodyId, mass, k, new Vector3(0, 0, 0), angularFactors, friction);
               // contador.bodynum = 0;
            }
        }*/
    }
    static object Lock = new object();
    private static int curId = -1;
    public static int getNextBodyId()
    {
        lock (Lock)
        {
            curId++;
            return curId;
        }
    }
}
