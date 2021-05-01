using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoadingSystem : MonoBehaviour
{
    public GameObject panel;
    public Text panelOperation;
    public bool isLoading;
    
    
    
    public static LoadingSystem Instance;
    private static GameObject Panel;
    private static Text PanelOperation;
    private static bool IsLoading;

    private void Awake()
    {
        Instance = this;
        Panel = panel;
        PanelOperation = panelOperation;
        isLoading = IsLoading;
    }

    public static void LoadOperation(string operation)
    {
        Panel.SetActive(true);
        PanelOperation.text = operation;
        IsLoading = true;
    }
}