using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingSystem : MonoBehaviour
{
    public static LoadingSystem Instance;
    public GameObject panel;
    public Text panelOperation;
    public bool isLoading;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadOperation(string operation)
    {
        panel.SetActive(true);
        panelOperation.text = operation;
        isLoading = true;
    }
}