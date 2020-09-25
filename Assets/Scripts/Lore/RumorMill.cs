using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumorMill : MonoBehaviour
{
    public int folks;
    public float rumorStrength;

    public float rumorSpreadRate = 0.15f;

    void Start()
    {
        folks = 0;
        rumorStrength = 0f;
    }

    void Update()
    {
        rumorStrength += Time.deltaTime * folks * (1f + rumorSpreadRate);
    }

}
