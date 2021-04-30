using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    Rigidbody2D controller;
    void Start()
	{
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
	{
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        Vector2 moveVector = transform.up * x * speed +transform.right* y * speed;

        controller.AddForce(moveVector);

    }





}
