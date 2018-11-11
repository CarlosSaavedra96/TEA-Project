using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felicitaciones : MonoBehaviour {

    
    public GameObject obj;
    private bool running = false;
    public float tiempo = 0;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (tiempo > 2)
        {
            obj.SetActive(true);
            invisible i = new invisible(obj,0);
            
        }

        if (running)
            tiempo = tiempo + (Time.deltaTime * 1);
    }


    public void SetTime()
    {
        running = true;
    }

    public void StopTime()
    {
        running = false;
        tiempo = 0;
    }
}
