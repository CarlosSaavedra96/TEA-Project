using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour {

    public GameObject obj;
    public float tiempo;
    private AudioSource fuente;
    public GameObject obj_audio;
    public AudioClip salir;
    private int bandera = 0;
	// Use this for initialization
	void Start () {
        fuente = obj_audio.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
        if (tiempo < 7)
        {
            tiempo = tiempo + (Time.deltaTime * 1);
            

        }
        else {
            obj.SetActive(false);
            tiempo = 0;
            if (bandera == 0)
            {
                fuente.clip = salir;
                fuente.Play();
                bandera = 1;
            }

        }
    }

    public invisible(GameObject o, float t)
    {
        this.obj = o;
        this.tiempo = t;
    }

    public void hide() {
        obj.SetActive(false);
    }
}
