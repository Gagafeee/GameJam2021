using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    public float jumpForce = 10f;


    [SerializeField]
    Rigidbody2D controller;

    private Vector3 velocity = Vector3.zero;
    public bool Jumping = false;
    public bool isGrounded = false;
    public bool movementIsEnabled = true;

    void Start()
	{
        Application.targetFrameRate = 60;
    }

    void FixedUpdate()
	{
        if (movementIsEnabled)
        {


            if (Input.GetButtonDown("Jump"))
            {
                Jumping = true;
                Debug.Log("wasabi");
            }
            float y = Input.GetAxis("Horizontal");

            Vector3 moveVector = transform.right * y * speed;
            controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref velocity, .03f);

            if (Jumping)
            {
                controller.AddForce(new Vector2(0f, jumpForce));
                Jumping = false;
            }
        }
    }





}
