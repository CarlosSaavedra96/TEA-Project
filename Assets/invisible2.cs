using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible2 : MonoBehaviour {


    public GameObject obj;
    public float tiempo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo < 7)
        {
            tiempo = tiempo + (Time.deltaTime * 1);

        }
        else
        {
            obj.SetActive(false);
            tiempo = 0;

        }
    }

    public invisible2(GameObject o, float t)
    {
        this.obj = o;
        this.tiempo = t;
    }

    public void hide()
    {
        obj.SetActive(false);
    }
}
