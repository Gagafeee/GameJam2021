using System;
using UnityEngine;
using System.Collections;


namespace Game
{
    public class playerController : MonoBehaviour
    {
        public static playerController Instance;
        [SerializeField] float speed = 10f;
        [SerializeField] public float jumpForce = 10f;
        [SerializeField] public Rigidbody2D controller;
        private Vector3 _velocity = Vector3.zero;
        public bool jumping = false;
        public bool isGrounded = false;
        public bool movementIsEnabled = true;
        public Animator playerAnimator;
        [SerializeField] private Vector3 velocity;


        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Application.targetFrameRate = 60;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnTriggerStay2D(Collider2D groundcheck)
        {
            if (groundcheck.CompareTag("Ground") || groundcheck.CompareTag("Plateform"))
            {
                 isGrounded = true;
            }
           
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
          //  if(other.Distance())
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            isGrounded = false;
        }


        void FixedUpdate()
        {
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetFloat("Speed", controller.velocity.x);
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetBool("isGrounded", isGrounded);

            if (!movementIsEnabled) return;
            if (Input.GetButtonDown("Jump") & isGrounded)
            {
                StartCoroutine(Jump());
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




            if (jumping)

            {
                
              controller.AddForce(new Vector2(0f, jumpForce));
                          jumping = false;
            }
            
            
        }

        public IEnumerator Jump()
        { 
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetTrigger("Jump");
            yield return new WaitForSeconds(0.1f);
            
            
            
        }
        
    }
}