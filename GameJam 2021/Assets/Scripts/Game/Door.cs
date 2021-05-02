using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BorderMagager.instance.isActive = false;
        SceneManager.LoadScene("Win");
        Cursor.lockState = CursorLockMode.None;
    }
}
