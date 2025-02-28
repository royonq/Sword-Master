using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winn : MonoBehaviour
{
    private void OnEnable()
    {
        StartStopWave.OnGameWin += GameWinn;
    }

    private void OnDisable()
    {
        StartStopWave.OnGameWin -= GameWinn;
    }

    private void GameWinn()
    {
        Debug.Log("The Winn");  
    }
}
