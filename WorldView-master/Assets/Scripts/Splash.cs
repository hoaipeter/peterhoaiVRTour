﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public int level = 1;    //Level to open after splash
    public float setTime = 3.0f;    //Duration before loading next level
    public float dimTime = 2.0f;  //Duration Before Staring to Fade or Dim Lights
    public Light dimLight;   //Main Light Source to Dim
    public float zoomSpeed = 0.2f;   //Speed at which camera zooms in

    Camera c;
    float timer;     // Use this for initialization

    // Use this for initialization
    void Start () {
        c = GetComponent<Camera>();    //Find attached Camera Component
        timer = 0.0f; //Initializes Timer to 0
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime; //Adds Time.deltaTime to timer each update
        c.fieldOfView -= zoomSpeed; //Zooms in Camera
        if (timer > dimTime && timer < setTime)
        {
            dimLight.intensity -= zoomSpeed; //Dims Lights
        }
        else if (timer > setTime)
        {
            //Loads Level at index
            SceneManager.LoadScene(level);
        }
    }
}
