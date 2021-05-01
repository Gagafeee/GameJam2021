using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

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

        public Slider jumpSlider;

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
                StartCoroutine(JumpEvent());

            }
            float y = Input.GetAxis("Horizontal");


            Vector3 moveVector = transform.right * y * speed;
            controller.velocity = Vector3.SmoothDamp(controller.velocity, moveVector, ref _velocity, .03f);




            if (jumping)
            {

                
                
                controller.AddForce(new Vector2(0f, jumpForce));
                jumping = false;
            }
            
            

            
        }


        public IEnumerator JumpEvent()
        {
            for (float i = jumpSlider.value; i < 0; i--)
            {
                jumpSlider.value--;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
