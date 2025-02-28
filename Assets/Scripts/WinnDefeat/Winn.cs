using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winn : MonoBehaviour
{
    private void OnEnable()
    {
        WaweSystem.OnGameWinn += TheWinn;
    }

    private void OnDisable()
    {
        WaweSystem.OnGameWinn -= TheWinn;
    }

    private void TheWinn()
    {
        Debug.Log("The Winn");  
    }
}
