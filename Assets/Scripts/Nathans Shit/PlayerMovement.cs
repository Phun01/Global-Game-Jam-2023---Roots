using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        //public Joystick joy;
        public GameObject joyStick;

        public int playerNo;

        [Header("Game Mode")]
        public controllerMode currentMode;

        public bool doomControl;
        public bool modernControl;
        public bool mobileControl;
        public bool mobileControl1;

        [Header("Moving")]
        public float moveSpeedDoom;
        public float moveSpeedMordern;

        //[SerializeField] float jumpSpeed;

        public float walkTime;
        float walkTimer;

        public bool walking;

        [Header("Turning")]
        public bool turning;
        public float rotateSpeed;
        public float mouseScence;

        [Header("Inputs")]
        public float verticalInput;
        public float horizontalInput;
        public float verticalInput1;
        public float horizontalInput1;

        bool backWards;

        [Header("Fall")]
        public bool isGrounded;
        public float fallRate;
        public float fallCoolDown = 1f;
        float fallCoolDownTimer;

        [Header("Climbing")]
        public bool climbing;
        public bool upDownClimb;
        public float climbSpeed;
        public float climbCoolDown = 1f;
        public bool canUp;

        public bool strafeLeft;
        public bool strafeRight;

        public bool rotateLeft;
        public bool rotateRight;

        public enum controllerMode
        {
            DOOM,
            MODERN,
            MOBILE,
            MOBILE1
        }

        private void Awake()
        {
            switch (currentMode)
            {
                case (controllerMode.DOOM):
                    doomControl = true;
                    modernControl = false;
                    mobileControl = false;
                    mobileControl1 = false;
                    break;

                case (controllerMode.MODERN):
                    doomControl = false;
                    modernControl = true;
                    mobileControl = false;
                    mobileControl1 = false;
                    break;

                case (controllerMode.MOBILE):
                    doomControl = false;
                    modernControl = false;
                    mobileControl = true;
                    mobileControl1 = false;
                    break;

                case (controllerMode.MOBILE1):
                    doomControl = false;
                    modernControl = false;
                    mobileControl = false;
                    mobileControl1 = true;
                    break;
            }
        }

        Rigidbody m_Rigidbody;
        //GameController gameController;
        //Audio audio;

        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            //audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio>();

            /*if (!gameController.mobileControl)
            {
                joyStick.SetActive(false);
            }*/
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!climbing)
            {
                Movement();
                //Rotation();
                Fall();
                m_Rigidbody.useGravity = true;
            }/*
            else
            {
                Climbing();
            }*/

            if(walking || turning)
            {
                walkTimer += Time.deltaTime;
                if (walkTimer >= walkTime)
                {
                    //audio.FootSteps();
                    walkTimer = 0;
                }
            }

           

            MobileExtraButtons();
        }

        private void Update()
        {
            if (playerNo <= 1)
            {
                verticalInput = Input.GetAxis("Vertical");
                horizontalInput = Input.GetAxis("Horizontal");
                horizontalInput1 = Input.GetAxis("Horizontal1");
                verticalInput1 = Input.GetAxis("Vertical1");
            }

            if (playerNo > 1)
            {
                verticalInput = Input.GetAxis("P2Vertical");
                horizontalInput = Input.GetAxis("P2Horizontal");
                horizontalInput1 = Input.GetAxis("P2Horizontal1");
                verticalInput1 = Input.GetAxis("P2Vertical1");
            }
        }

        void Movement()
        {
            if (doomControl)
            {

                if (verticalInput > 0.1)
                {
                    m_Rigidbody.velocity = transform.forward * moveSpeedDoom;
                }

                if (verticalInput < -0.1)
                {
                    m_Rigidbody.velocity = -transform.forward * moveSpeedDoom;
                    backWards = true;
                }
                else
                {
                    backWards = false;
                }
            }

            if (modernControl)
            {


                if (verticalInput > 0.3)
                {
                    m_Rigidbody.AddForce(-transform.forward * moveSpeedMordern);
                }
                else if (verticalInput < -0.3)
                {
                    m_Rigidbody.AddForce(transform.forward * moveSpeedMordern);
                }

                if (horizontalInput > 0.3)
                {
                    m_Rigidbody.AddForce(transform.right * moveSpeedMordern);
                }
                else if (horizontalInput < -0.3)
                {
                    m_Rigidbody.AddForce(-transform.right * moveSpeedMordern);
                }
            }

            
           
            if (verticalInput != 0 || horizontalInput != 0 || strafeLeft || strafeRight)
            {
                walking = true;
            }
            else
            {
                walking = false;  
            }
        }

        void Rotation()
        {
            if (doomControl)
            {

                if (horizontalInput1 > 0)
                {
                    transform.Rotate(new Vector3(0, Mathf.Lerp(0f, 1f, horizontalInput1), 0) * Time.deltaTime * rotateSpeed);
                }
                if (horizontalInput1 < 0)
                {
                    transform.Rotate(new Vector3(0, Mathf.Lerp(-1f, 0f, horizontalInput1), 0) * Time.deltaTime * rotateSpeed);
                }
            }

            if(mobileControl)
            {
                //horizontalInput1 = joy.Horizontal;
                if (horizontalInput1 > 0)
                {
                    transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
                }
                if (horizontalInput1 < 0)
                {
                    transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
                }
            }

            if (modernControl)
            {
               

                if (horizontalInput1 > 0)
                {
                    transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
                }
                if (horizontalInput1 < 0)
                {
                    transform.Rotate(new Vector3(0, horizontalInput1, 0) * Time.deltaTime * rotateSpeed);
                }
                /*
                if (playerNo == 1)
                {
                    float mousehorizontalInput1 = Input.GetAxis("Mouse X");
                    float mouseverticalInput1 = Input.GetAxis("Mouse Y");
                    if (mousehorizontalInput1 > 0)
                    {
                        transform.Rotate(Vector3.up * mouseScence);
                    }
                    if (mousehorizontalInput1 < 0)
                    {
                        transform.Rotate(Vector3.up * -mouseScence);
                    }
                }*/

                
            }

            

            if (horizontalInput1 != 0)
            {
                turning = true;
            }
            else
            {
                turning = false;
            }
        }


        void MobileExtraButtons()
        {
            if(strafeLeft)
            {
                m_Rigidbody.velocity = -transform.right * moveSpeedDoom;
            }

            if (strafeRight)
            {
                m_Rigidbody.velocity = transform.right * moveSpeedDoom;
            }

            if(rotateLeft)
            {
                transform.Rotate(new Vector3(0, Mathf.Lerp(0f, -1f, 1f), 0) * Time.deltaTime * rotateSpeed);
            }
            if(rotateRight)
            {
                transform.Rotate(new Vector3(0, Mathf.Lerp(0f, 1f, 1f), 0) * Time.deltaTime * rotateSpeed);
            }
        }
        /*
        void Climbing()
        {
            m_Rigidbody.useGravity = false;

            if (!mobileControl)
            {
                verticalInput = Input.GetAxis("Vertical");
            }
            else
            {
                //verticalInput = joy.Vertical;
            }

            if (verticalInput > 0 && canUp)
            {
                m_Rigidbody.velocity = transform.up * climbSpeed;
            }
            if (verticalInput < 0)
            {
                m_Rigidbody.velocity = -transform.up * climbSpeed;
            }

            if (verticalInput != 0)
            {
                walking = true;
            }
            else
            {
                walking = false;
            }
        }*/

        void Fall()
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, -this.transform.up, out hit, 1.1f))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            if (!isGrounded)
            {
                fallCoolDownTimer += Time.deltaTime;
                if (fallCoolDownTimer >= fallCoolDown)
                {
                    m_Rigidbody.AddForce(-transform.up * fallRate);
                }
            }
            else
            {
                fallCoolDownTimer = 0;
            }
        }

      
    }
}
