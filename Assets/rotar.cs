using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour {

    public float spinForce;
    private bool running = false;
    public float tiempo = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(tiempo > 2)
            transform.Rotate(0,spinForce * Time.deltaTime,0);
        if(running)
            tiempo = tiempo + (Time.deltaTime * 1);

    }

    public void SetRotate()
    {
        running = true;
    }

    public void StopTime()
    {
        running = false;
        tiempo = 0;
    }

    public void contadorTime()
    {
        tiempo = tiempo + (Time.deltaTime * 1);
    }

}
