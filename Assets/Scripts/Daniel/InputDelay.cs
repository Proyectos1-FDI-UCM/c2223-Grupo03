using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDelay : MonoBehaviour
{
    [SerializeField] double _delay = 0.5;
    private double _time = 0;

    void Update()
    {
        _time += Time.deltaTime;
    }

    public void ResetTime()
    {
        _time = 0;
    }
    public bool TryInput()
    {
        if (_time >= _delay)
        {
            ResetTime();
            return true;
        }
        else { return false; }
    }

}
