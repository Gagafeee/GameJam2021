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
        Die();
    }

    private void Awake()
    {
        instance = this;
    }


    public void Die()
    {
        isDie = true;
        playerController.Instance.movementIsEnabled = false;
        cameraFollow.Instance.isActive = false;
        //border.Instance.isActive = false;
        StartCoroutine(Respawn());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public IEnumerator Respawn()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        cameraFollow.Instance.smoothSpeed = 50;
        panel.SetActive(true);
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        respawnAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(4.3f);
        player.transform.position = respawnPoint.transform.position;
        panel.SetActive(false);
        playerController.Instance.movementIsEnabled = true;
        playerController.Instance.controller.bodyType = RigidbodyType2D.Dynamic;
        cameraFollow.Instance.isActive = true;
        //border.Instance.isActive = false;
        panel.SetActive(false);
        isDie = false;
        GetComponent<BoxCollider2D>().enabled = true;
        cameraFollow.Instance.smoothSpeed = 12;
    }
}