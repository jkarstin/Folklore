using System.Collections;
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
        private float curiosity;
        
        public Personality()
        {

        }

    }

}
