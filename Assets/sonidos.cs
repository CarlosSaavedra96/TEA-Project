using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidos : MonoBehaviour {

    public AudioClip bienvenida;
    public AudioClip problema;
    public AudioClip solucion;

    AudioSource fuente;

    private float tiempo = 0;
    private int bandera = 0;

	// Use this for initialization
	void Start () {
        fuente = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        tiempo = tiempo + (Time.deltaTime * 1);
        if (tiempo > 1 && bandera == 0) {
            fuente.clip = bienvenida;
            fuente.Play();
            bandera = 1;
        }
        if (tiempo > 4 && bandera == 1)
        {
            fuente.clip = problema;
            fuente.Play();
            bandera = 2;
        }
        if (tiempo > 6 && bandera == 2)
        {
            fuente.clip = solucion;
            fuente.Play();
            bandera = 3;
        }

    }
}
