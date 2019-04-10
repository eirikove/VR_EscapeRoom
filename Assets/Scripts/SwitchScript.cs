using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class SwitchScript : MonoBehaviour
{

    private GameObject[] lights;


    public int currentState; // on
    private Transform cubeSwitch;
    public TextMeshPro yellowClue;



    void Start()
    {
        Debug.Log("Started LightSwitch script");
        cubeSwitch = GameObject.FindGameObjectWithTag("lightswitch").GetComponent<Transform>();
        yellowClue = GameObject.FindGameObjectWithTag("yellowClue").GetComponent<TextMeshPro>();
        currentState = 1;
    }

    public void switchEffect()
    {
        Debug.Log("Triggered Switch Effect");
        if (currentState == 1) {
            cubeSwitch.position += (Vector3.forward) * (-0.02f);
            lights = GameObject.FindGameObjectsWithTag("roomLight");
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Light>().enabled = false;
            }
            currentState = 0; // off
        }

        else if(currentState == 0)
        {            
            cubeSwitch.position += (Vector3.back) * (-0.02f);
            lights = GameObject.FindGameObjectsWithTag("roomLight");
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].GetComponent<Light>().enabled = true;
            }
            currentState = 1; // on
        }
    }

    public void enableClue()
    {
        if(currentState == 0)
        {
            Debug.Log("Enabled yellow clue");
            yellowClue.enabled = true;
        }
        else
        {
            disableClue();
        }
        
    }
    
    public void disableClue()
    {
        Debug.Log("Disabled yellow clue");
        yellowClue.enabled = false;
    }

}
