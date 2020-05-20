using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarniv2 : MonoBehaviour {
    private GameObject pieza;
    private GameObject pieza1;
    private Transform partes;
    private Transform partes1;
 
    private int aciertos = 15;
    private int aux = 0;
    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;
    public Vector3 pos5;
    public Vector3 pos6;
    public Vector3 pos7;
    public Vector3 pos8;
    public Vector3 pos9;
    public Vector3 pos10;
    public Vector3 pos11;
    public Vector3 pos12;
    public Vector3 pos13;
    public Vector3 pos14;
    public Vector3 pos15;
    public Vector3 pos16;
    
    int Rand;
    int Lenght = 17;
    List<int> list = new List<int>();
    List<Vector3> posiciones;

    void Start()
    {
        //  minX = -20.0f; maxX = 20.0f;
        //  minY = -10.0f; maxY = 10.0f;
        //minZ = -7.0f; maxZ = 4.0f;
        posiciones = new List<Vector3>();
        posiciones.Add(pos1);
        posiciones.Add(pos2);
        posiciones.Add(pos3);
        posiciones.Add(pos4);
        posiciones.Add(pos5);
        posiciones.Add(pos6);
        posiciones.Add(pos7);
        posiciones.Add(pos8);
        posiciones.Add(pos9);
        posiciones.Add(pos10);
        posiciones.Add(pos11);
        posiciones.Add(pos12);
        posiciones.Add(pos13);
        posiciones.Add(pos14);
        posiciones.Add(pos15);
        posiciones.Add(pos16);
        

        aux = 0;

        list = new List<int>(new int[Lenght]);

        for (int j = 1; j < Lenght; j++)
        {
            Rand = Random.Range(1, 17);

            while (list.Contains(Rand))
            {
                Rand = Random.Range(1, 17);
            }

            list[j] = Rand;

            string a = j.ToString();
            pieza = GameObject.Find("puzzle1");
            partes = pieza.transform.Find(a);
            partes.position = posiciones[list[j] - 1];

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (contador.piezasbuenas > aciertos)
        {
            aciertos = aciertos + 1;
            for (int y = 1; y < 17; y++)
            {
                string a = y.ToString();
                pieza = GameObject.Find("puzzle1");
                pieza1 = GameObject.Find("puzzle1ref");
                partes = pieza.transform.Find(a);
                partes1 = pieza1.transform.Find(a + " (1)");
                if (Vector3.Distance(partes.position, partes1.position) < 0.5)
                {
                    aux = 1;
                }
                else
                {
                    aux = 0;
                    Debug.Log("Pieza incorrecta");
                    break;
                }

            }

        }



        if (aciertos > 15)
        {
            if (aux == 1)
            {
                Debug.Log("Ganaste");
                contador.ganador = 1;
            }
            else
            {
                Debug.Log("Perdiste");
                contador.ganador = 0;
            }
        }
    }
}