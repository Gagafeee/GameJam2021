using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieZone : MonoBehaviour
{
    public Animator respawnAnimator;
    public GameObject panel;
    public GameObject player;
    public GameObject respawnPoint;
    public static DieZone instance;
    public bool isDie;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           Die(); 
        }
        
    }

    private void Awake()
    {
        instance = this;
    }


    public void Die()
    {
        isDie = true;

        playerController.Instance.controller.bodyType = RigidbodyType2D.Dynamic;
        BorderMagager.instance.isActive = false;
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        playerController.Instance.playerAnimator.SetTrigger("Die");
        StartCoroutine(Respawn());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator Respawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        cameraFollow.Instance.smoothSpeed = 50;
        panel.SetActive(true);
        
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        playerController.Instance.playerAnimator.SetTrigger("Revive");
        player.transform.position = respawnPoint.transform.position;
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        respawnAnimator.SetBool("Die", true);
        yield return new WaitForSeconds(4.3f);
        panel.SetActive(false);
        StartCoroutine(PausePanel.instance.ResumeCor());
        isDie = false;
        GetComponent<BoxCollider2D>().enabled = true;
        cameraFollow.Instance.smoothSpeed = 12;
        player.transform.position = respawnPoint.transform.position;
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        respawnAnimator.SetBool("Die", false);
    }
}