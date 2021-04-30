using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject Panel;
    public bool isInPause;
    public Component playerControllerScript;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInPause == false)
            {
                Pause();
            }

            if (isInPause)
            {
                Resume();
            }
        }


    }

    public void Pause()
    {
        //playerController.Instance.movementIsEnabled = false;
        cameraFollow.Instance.isActive = false;
        Panel.SetActive(true);
        isInPause = true;
    }

    public void Resume()
    {
        Panel.SetActive(false);
        player.playerControllerScript.movementIsEnabled = true;
        cameraFollow.Instance.isActive = true;
        isInPause = false;
    }
    
}
