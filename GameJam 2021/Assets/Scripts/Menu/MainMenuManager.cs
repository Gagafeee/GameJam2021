using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator mainPanelAnimator;

    public void EnlargePanel()
    {
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        mainPanelAnimator.SetBool("isTargeted", true);
    }

    public void MinimizePanel()
    {
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        mainPanelAnimator.SetBool("isTargeted", false);
    }

    public void QuitApp()
    {
        LoadingSystem.LoadOperation("Application.Quit(0)");
        Application.Quit();
    }

    public void Play()
    {
        LoadingSystem.LoadOperation("Scene.load(Play())");
        SceneManager.LoadSceneAsync("Game");
    }
}
