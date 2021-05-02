using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiqueManager : MonoBehaviour
{
    public AudioLowPassFilter AudioLowPassFilter;

    private void Start()
    {
        AudioLowPassFilter.lowpassResonanceQ = 1;
    }

    private void Update()
    {
        if (DieZone.instance.isDie)
        {
            AudioLowPassFilter.cutoffFrequency = 500;
        }
        else
        {
            AudioLowPassFilter.cutoffFrequency = 22000;
        }
    }
}
