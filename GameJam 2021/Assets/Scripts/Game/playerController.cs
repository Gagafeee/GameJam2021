using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class playerController : MonoBehaviour
    {
        public static playerController Instance;
        [SerializeField]
        float speed = 10f;
        [SerializeField]
        public float jumpForce = 10f;


        [SerializeField]
        public Rigidbody2D controller;
        [SerializeField]
        public Transform groundCheckLeft;
        [SerializeField]
        public Transform groundCheckRight;

        private Vector3 _velocity = Vector3.zero;
        public bool jumping = false;
        public bool isGrounded = false;
        public bool movementIsEnabled = true;



        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {

            Application.targetFrameRate = 60;
        }



        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapArea(groundCheckLeft.position,groundCheckRight.position);


            if (!movementIsEnabled) return;
            if (Input.GetButtonDown("Jump")  & isGrounded )
            {
                jumping = true;

            }


            float y = Input.GetAxis("Horizontal");
            if(y < 0)
			{
                y = 0;
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


    }
}
