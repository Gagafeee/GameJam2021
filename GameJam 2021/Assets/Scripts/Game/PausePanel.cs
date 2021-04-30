using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject Panel;


    public void Pause()
    {
        playerController.Instance.movementIsEnabled = false;
        Panel.SetActive(true);
        
    }
    
}
