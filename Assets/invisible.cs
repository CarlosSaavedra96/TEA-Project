using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour {

    public GameObject obj;
    public float tiempo;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
        if (tiempo < 5)
        {
            tiempo = tiempo + (Time.deltaTime * 1);

        }
        else {
            obj.SetActive(false);
            tiempo = 0;
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
