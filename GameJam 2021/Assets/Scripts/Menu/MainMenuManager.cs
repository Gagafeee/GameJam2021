using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator mainPanelAnimator;

    public void enlargePanel()
    {
        mainPanelAnimator.SetBool("isTargeted", true);
    }

    public void minimizePanel()
    {
        mainPanelAnimator.SetBool("isTargeted", false);
    }

    public void quitApp()
    {
        LoadingSystem.Instance.LoadOperation("Application.Quit(0)");
        Application.Quit();
    }

    public void play()
    {
        LoadingSystem.Instance.LoadOperation("Event.Play()");
        SceneManager.LoadScene("Game");
    }
}
