﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folk : MonoBehaviour
{
    private Personality personality;
    
    void Start()
    {
        personality = new Personality();
    }

    void Update()
    {
        
    }

    public class Personality
    {
        public float curiosity;
        public float scrutiny;
        public float resillience;
        public float honesty;
        public float extroversion;
        
        public Personality()
        {
            curiosity    = Random.Range(0f, 10f);
            scrutiny     = Random.Range(0f, 10f);
            resillience  = Random.Range(0f, 10f);
            honesty      = Random.Range(0f, 10f);
            extroversion = Random.Range(0f, 10f);
        }

    }

}
