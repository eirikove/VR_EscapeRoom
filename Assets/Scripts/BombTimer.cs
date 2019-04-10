using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using TMPro;

public class BombTimer : MonoBehaviour
{
    public static Timer timer1;
    static String time;
    static TextMeshPro timerText = new TextMeshPro();
    private float totalTime;
    public float TotalTime{ get => totalTime; set => totalTime = value; } // seconds

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshPro>();
        TotalTime = 900f;
        enabled = true;
    }

    
    // Update is called once per frame
    private void Update()
    {
            totalTime -= Time.deltaTime;
            
            UpdateLevelTimer(totalTime);
            if (totalTime < -1)
            {
                enabled = false;
            }
  

        
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        if(totalTime <= 0)
        {
            timerText.text = "--:--";
        }
        else
        {
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
