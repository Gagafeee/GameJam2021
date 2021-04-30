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
    [SerializeField]
    public Transform groundCheckLeft;
    [SerializeField]
    public Transform GroundCheckRight;

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
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position,GroundCheckRight.position);


        if (movementIsEnabled)
        {
            if (Input.GetButtonDown("Jump")  & isGrounded )
            {
                Jumping = true;

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
