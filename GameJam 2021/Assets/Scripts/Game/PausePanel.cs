using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject panel;
    public bool isInPause;
    public Animator panelAnimator;

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
        panel.SetActive(true);
        StartCoroutine(PauseCor());
        isInPause = true;
    }

    private IEnumerator PauseCor()
    {
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        panelAnimator.SetBool("isVisible", true);
        yield return new WaitForSeconds(0.30f);
        playerController.Instance.movementIsEnabled = false;
        playerController.Instance.controller.bodyType = RigidbodyType2D.Static;
        cameraFollow.Instance.isActive = false;
        //border.Instance.isActive = false;
                
    }

    public void Resume()
    {
<<<<<<< Updated upstream
        StartCoroutine(ResumeCor());
        
=======
        Panel.SetActive(false);
        //player.playerControllerScript.movementIsEnabled = true;
        cameraFollow.Instance.isActive = true;
>>>>>>> Stashed changes
        isInPause = false;
    }

    public IEnumerator ResumeCor()
    {
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        panelAnimator.SetBool("isVisible", false);
        yield return new WaitForSeconds(0.30f);
        playerController.Instance.movementIsEnabled = true;
        playerController.Instance.controller.bodyType = RigidbodyType2D.Dynamic;
        cameraFollow.Instance.isActive = true;
        //border.Instance.isActive = false;
        panel.SetActive(false);
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
