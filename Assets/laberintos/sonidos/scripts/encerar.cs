using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encerar : MonoBehaviour {

	// Use this for initialization
	void Start () {
         //lab
    contador.numero_choques = 0;
       contador.numero_llegada = 0;
        contador.cronometro = 0;
        contador.fuerza = 0;
        contador.puerta = 0;
    contador.ini = 0;


    //puzzles
    contador.pieza = 0;
    contador.piezaagarrada = 0;
    contador.piezasbuenas = 0;
    contador.piezasmalas = 0;
    contador.ganador = 0;
    contador.errores = 0;
    contador.modo = 0;
    contador.peso = 0;

    //precision
    contador.taladro = 0;
    contador.aciertos = 0;
    contador.error_taladro = 0;
    contador.ganador_taladro = 0;
    contador.peso_taladro = 0;
    contador.bandera = 0;
    contador.broca = 0;
    contador.bloqueo = 0;

    //pruebas

    contador.activacion = false;


    //consultorio
    contador.b_instanciar = 0;
    contador.ganador_consultorio = 0;
    contador.acierto = 0;
    contador.borrar = 0;
    contador.saber = 0;
    contador.fallos = 0;
    contador.primer = 0;
    contador.mensaje = 0;
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
