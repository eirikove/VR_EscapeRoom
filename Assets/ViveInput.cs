﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
/*
public class ViveInput : MonoBehaviour
{

    [SteamVR_DefaultAction("Squeeze")];

    public SteamVR_Action_Single squeezeAction;

    public SteamVR_Action_Vector2 touchPadAction;


    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("Teleport down");
        }

        if (SteamVR_Input._default.inActions.GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            print("Grab pinch up");
        }
    }
    /*
    float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);
        if(triggerValue > 0.0f) {
        print(triggerValue);
    }

    private Vector2 touchPadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        if(touchPadValue != Vector2.zero) {
        print(touchPadValue);
    }*/