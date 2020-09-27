using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorld : MonoBehaviour
{
    private int[] timeData;
    private float s;
    private bool paused;

    public Transform sun;
    public Transform moon;
    public float worldTimeSpeed = 30f;
    public Text timeText;

    void Start()
    {
        timeData = new int[] {0, 0, 0, 0, 0};

        sun.localEulerAngles = new Vector3(270f, 0f, 0f);

        s = 0f;
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            paused = !paused;
        }

        if (!paused) s += Time.deltaTime * worldTimeSpeed;

        if (s >= 60f)
        {
            timeData[4] += (int)s / 60;
            
            timeData[3] += timeData[4] / 60;
            timeData[4] %= 60;

            timeData[2] += timeData[3] / 24;
            timeData[3] %= 24;

            timeData[1] += timeData[2] / 30;
            timeData[2] %= 30;

            timeData[0] += timeData[1] / 12;
            timeData[1] %= 12;

            s -= ((int)s / 60) * 60f;
        }

        float a = 270f + timeData[4] / 4f + timeData[3] * 15f;

        sun.localEulerAngles = new Vector3(a, 0f, 0f);
        moon.localEulerAngles = new Vector3(a + 180f, 0f, 0f);

        updateTimePanel();
    }

    private void updateTimePanel()
    {
        string hours = "00", minutes = "00";

        hours = (timeData[3] >= 10) ? "" + timeData[3] : "0" + timeData[3];

        minutes = (timeData[4] >= 10) ? "" + timeData[4] : "0" + timeData[4];

        timeText.text = hours + ":" + minutes;
    }

}
