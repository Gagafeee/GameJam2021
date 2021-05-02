using System;
using UnityEngine;
using System.Collections;


namespace Game
{
    public class playerController : MonoBehaviour
    {
        public static playerController Instance;
        [SerializeField] float speed = 10f;
        [SerializeField] public float jumpForce = 300;
        [SerializeField] public Rigidbody2D controller;
        private Vector3 _velocity = Vector3.zero;
        public bool jumping = false;
        public bool isGrounded = false;
        public bool movementIsEnabled = true;
        public Animator playerAnimator;
        private Vector3 velocity;


        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            jumpForce = 300;
            movementIsEnabled = true;
        }

        private void OnTriggerStay2D(Collider2D groundcheck)
        {
            if (groundcheck.CompareTag("Ground") || groundcheck.CompareTag("Plateform"))
            {
                 isGrounded = true;
            }
           
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            isGrounded = false;
        }


        void FixedUpdate()
        {
            
            Debug.Log("log :" + "Movement : " + movementIsEnabled + " " + "jumpForce : " + jumpForce + " " + "Jumping : " + jumping);
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetFloat("Speed", controller.velocity.x);
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetBool("isGrounded", isGrounded);

            if (!movementIsEnabled) return;
            if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
            {
                StartCoroutine(Jump());
                PlateformManager.instance.MovePlatform();
                
                
            }

            float y = Input.GetAxis("Horizontal");
            if (y < 0)
            {
                y = 0f;
            }

            Vector3 moveVector = transform.right * y * speed;

            moveVector.y = controller.velocity.y;

            if (movementIsEnabled)
            { 
                controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref _velocity, .03f);
                if (!jumping) return;
                controller.AddForce(new Vector2(0f, jumpForce));
                jumping = false;
            }


            


        }

        public IEnumerator Jump()
        { 
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            playerAnimator.SetTrigger("Jump");
            yield return new WaitForSeconds(0.1f);
            jumping = true;
            isGrounded = false;

        }
        
    }
}