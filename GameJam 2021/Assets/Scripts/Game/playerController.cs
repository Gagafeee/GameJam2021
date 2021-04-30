using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    Rigidbody2D controller;
    private Vector3 velocity = Vector3.zero;
    void Start()
	{
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
	{
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        Vector3 moveVector = transform.up * x * speed +transform.right* y * speed;

        controller.velocity= Vector3.SmoothDamp(controller.velocity,moveVector,ref velocity, .05f);

    }





}
