using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject Panel;
    public bool isInPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInPause)
            {
                Resume();
            }
            else
            {
               Pause(); 
            }
            

        }


    }

    public void Pause()
    {
        playerController.Instance.movementIsEnabled = false;
        playerController.Instance.controller.bodyType = RigidbodyType2D.Static;
        cameraFollow.Instance.isActive = false;
        //border.Instance.isActive = false;
        Panel.SetActive(true);
        isInPause = true;
    }

    public void Resume()
    {
        Panel.SetActive(false);
        playerController.Instance.movementIsEnabled = true;
        playerController.Instance.controller.bodyType = RigidbodyType2D.Dynamic;
        cameraFollow.Instance.isActive = true;
        isInPause = false;
    }

    public void Menu()
    {
        LoadingSystem.LoadOperation("Scene.load(Menu())");
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Quit()
    {
        LoadingSystem.LoadOperation("Application.Quit(0)");
        Application.Quit();
    }
    
}
