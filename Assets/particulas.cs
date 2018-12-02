using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulas : MonoBehaviour {

    public GameObject obj;
    public float tiempo = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (tiempo < 10)
        {
            tiempo = tiempo + (Time.deltaTime * 1);

        }
        else
        {
            obj.SetActive(true);
            tiempo = 0;

        }
    }
}
