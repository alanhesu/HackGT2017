﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodo : MonoBehaviour {   
    public Vector2 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartFlying(float startHeight)
    {
        pos.x = 0;
        pos.y = startHeight;
    }
}
