<<<<<<< HEAD
using UnityEngine;
=======
>>>>>>> parent of 1ec1fd9 (Animation 2)
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    public class playerController : MonoBehaviour
    {
        public static playerController Instance;
        [SerializeField] float speed = 10f;
        [SerializeField] public float jumpForce = 10f;


        [SerializeField] public Rigidbody2D controller;
        [SerializeField] Collider2D Groundcheck;



        private Vector3 _velocity = Vector3.zero;
        public bool jumping = false;
        public bool isGrounded = false;
        public bool movementIsEnabled = true;


        public Animator playerAnimator;

        [SerializeField] Rigidbody2D controllerRB;
        [SerializeField] public Transform groundCheckLeft;
        [SerializeField] public Transform groundCheckRight;
        [SerializeField] private Vector3 velocity;


        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void OnTriggerEnter2D(Collider2D Groundcheck)
        {
            isGrounded = true;
            Debug.Log("change state grounded true");
        }

<<<<<<< HEAD
=======

>>>>>>> parent of 1ec1fd9 (Animation 2)

		void FixedUpdate()
        {
            //isGrounded = Physics2D.OverlapArea(groundCheckLeft.position,groundCheckRight.position);

<<<<<<< HEAD
            playerAnimator.SetFloat("Speed", controller.velocity.x);
=======
    playerAnimator.SetFloat("Speed", controller.velocity.x);
>>>>>>> parent of 1ec1fd9 (Animation 2)
            if (!movementIsEnabled) return;
            if (Input.GetButtonDown("Jump") & isGrounded)
            {
                PlateformManager.instance.MovePlatform();
                jumping = true;
                isGrounded = false;
            }

            float y = Input.GetAxis("Horizontal");
            if (y < 0)
            {
                y = 0f;
            }

            Vector3 moveVector = transform.right * y * speed;

            moveVector.y = controller.velocity.y;


            controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref _velocity, .03f);

            controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref _velocity, .03f);

<<<<<<< HEAD
            moveVector.y = controllerRB.velocity.y;

            
            controllerRB.velocity = Vector3.SmoothDamp(controllerRB.velocity, moveVector, ref velocity, .03f);
=======

>>>>>>> parent of 1ec1fd9 (Animation 2)


            if (jumping)

            {

                
                
                controller.AddForce(new Vector2(0f, jumpForce));
                jumping = false;

                {
                    controller.AddForce(new Vector2(0f, jumpForce));
                    jumping = false;

                    if (jumping)
                    {
                        controllerRB.AddForce(new Vector2(0f, jumpForce));
                        jumping = false;

                    }
                }
            }
        }
    }
}