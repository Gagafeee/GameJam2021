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

<<<<<<< Updated upstream
        private Vector3 _velocity = Vector3.zero;
        public bool jumping = false;
        public bool isGrounded = false;
        public bool movementIsEnabled = true;
=======
    [SerializeField]
    Rigidbody2D controllerRB;
    [SerializeField]
    public Transform groundCheckLeft;
    [SerializeField]
    public Transform GroundCheckRight;
>>>>>>> Stashed changes



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
<<<<<<< Updated upstream
            moveVector.y = controller.velocity.y;
            controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref _velocity, .03f);
=======
            moveVector.y = controllerRB.velocity.y;


            controllerRB.velocity = Vector3.SmoothDamp(controllerRB.velocity, moveVector, ref velocity, .03f);
>>>>>>> Stashed changes




<<<<<<< Updated upstream
            if (jumping)
            {   
                
                controller.AddForce(new Vector2(0f, jumpForce));
                jumping = false;
=======
            if (Jumping)
            {
                controllerRB.AddForce(new Vector2(0f, jumpForce));
                Jumping = false;
>>>>>>> Stashed changes
            }

            
        }


    }
}
