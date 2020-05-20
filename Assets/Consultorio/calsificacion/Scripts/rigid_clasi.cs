using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rigid_clasi : MonoBehaviour
{
    public float k = 0.5f;
    public float mass = 1;
    public Vector3 device_scale = new Vector3(1.0f, 1.0f, 1.0f);//send 1/4 size in the z dimension
    public int bodyId = 0;
    public Vector3 linearFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 angularFactors = new Vector3(1.0f, 1.0f, 1.0f);
    public float friction = 0.8f;
    private int numero;
    private int suelo;
    private bool removido = false;
    private bool inicio = true;
    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start()
    {
 
    /*    inicio = true;
        if (inicio && contador.permiso == 1)
        {
            Debug.Log("estoy");
            int d = 0;
            while (d < 10000)
            {
                d++;
                Debug.Log(d);
            }
            inicio = false;

        }*/
        bodyId = getNextBodyId();
        refreshShape();
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
      

        Vector3 pos;
            Quaternion orient;

            if (contador.bodynum == 0)

            {
                if (gameObject.tag == "cubo" || gameObject.tag == "cilindro" || gameObject.tag == "octa" || gameObject.tag == "triangulo" || gameObject.tag == "cubo_peque" || gameObject.tag == "cilindro_peque" || gameObject.tag == "octa_peque" || gameObject.tag == "triangulo_peque")
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
                }/*
            if (gameObject.tag == "cilindro")
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
            if (gameObject.tag == "octa")
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
            if (gameObject.tag == "triangulo")
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
            */
            }






            //Debug.Log(bodyId);
            /*      if (bodyId == numero)
                  {
                      if (removido)
                      {
                          if (contador.activacion)
                          {
                              refreshShape();
                              Debug.Log("vuelve");
                              removido = false;
                              contador.activacion = false;
                          }
                      }
                      else
                      {
                          if (contador.activacion)
                          {

                              FalconUnity.removeDynamicShape(numero);
                              removido = true;
                              contador.activacion = false;
                              Destroy(gameObject);
                          }
                      }
                  }*/
        
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
       
            Vector3 pos;
            Quaternion orient;
            if (contador.bodynum == 1 || contador.ganador_consultorio == 1)
            {
                if (gameObject.tag == "cubo")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                    
                }
                if (gameObject.tag == "cilindro")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                }
                if (gameObject.tag == "octa")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                }
                if (gameObject.tag == "triangulo")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Debug.Log("destruye");
                    Destroy(gameObject);
                }
                if (gameObject.tag == "cubo_peque")
                {
                    Debug.Log(bodyId);
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                }
                if (gameObject.tag == "cilindro_peque")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                }
                if (gameObject.tag == "octa_peque")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Destroy(gameObject);
                }
                if (gameObject.tag == "triangulo_peque")
                {
                    FalconUnity.removeDynamicShape(bodyId);
                    Debug.Log("destruye");
                    Destroy(gameObject);
                }
                // contador.bodynum = 0;
            }

            if (gameObject.tag != "cubo" && gameObject.tag != "cilindro" && gameObject.tag != "octa" && gameObject.tag != "triangulo" && gameObject.tag != "cubo_peque" && gameObject.tag != "cilindro_peque" && gameObject.tag != "octa_peque" && gameObject.tag != "triangulo_peque")
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

