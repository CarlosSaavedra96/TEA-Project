using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GIF : MonoBehaviour {

    public Texture2D[] frames;
    public int fps = 10;

    public GameObject container;
    float tiempo;
    void Update()
    {
        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];

        tiempo = tiempo + (Time.deltaTime * 1);
        if (tiempo > 7)
        {
            container.SetActive(false);
        }
    }
}
