using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using EZCameraShake;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        public int maxHealth = 100;
        public int currentHealth = 100;
        public HealthBar healthbar;

        private bool spiked = false;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        // public GameObject keyinv;
        //public GameObject mapinv;

        public bool isReversed;
        public bool isJumpReversed;
        public Bounds Bounds => collider2d.bounds;
        public bool hardmode;
        private bool shakeCam;
        private bool shakePlayer;
        private bool reversal = true;


        public float rotationMultiplier = 15f;
        // public float timeLeft = 80.0f;
        //   public GameObject red_screen;

        //public Text timeCount;

        public GameObject deathScreen;

        /*      IEnumerator CountDownToStart()
              {
                  while (countDownTime)
                  {

                  }
              }*/

        protected override void Start()
        {
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            deathScreen.SetActive(false);
            //  red_screen.SetActive(false);
            shakeCam = false;
            shakePlayer = false;


        }
        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

        }

        protected override void Update()
        {

            if (controlEnabled)
            {
                /*  if (hardmode)
                  {
                      timeLeft -=Time.deltaTime;
                      if (timeLeft < 0)
                      {
                          Death();
                      }
                      if (currentHealth % 20 == 0){
                           move.x = Input.GetAxis("Horizontal");
                       }
                      if(currentHealth % 20 != 0){
                             move.x = Input.GetAxis("Horizontal") * (-1);
                      }

                  }
                */
                if (hardmode  && reversal)
                {
                    move.x = Input.GetAxis("Horizontal") * (-1);
                }
                if(hardmode && !reversal)
                {
                    move.x = Input.GetAxis("Horizontal");
                }
                if (!isReversed && !hardmode)
                {
                    move.x = Input.GetAxis("Horizontal");

                }
                if (isReversed && !hardmode)
                {
                    move.x = Input.GetAxis("Horizontal") * (-1);
                    //if (!isReversed) { move.x = Input.GetAxis("Horizontal"); } else { move.x = Input.GetAxis("Horizontal") * (-1); }

                }

                if (!isJumpReversed && jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                {
                    animator.SetBool("running", false);
                    animator.SetTrigger("takeoff");
                    animator.SetBool("isJumping", true);

                    jumpState = JumpState.PrepareToJump;
                }

                if (isJumpReversed && jumpState == JumpState.Grounded && Input.GetButtonDown("JumpReversed"))
                {
                    animator.SetBool("running", false);
                    animator.SetTrigger("takeoff");
                    animator.SetBool("isJumping", true);

                    jumpState = JumpState.PrepareToJump;
                }

                else if (Input.GetButtonUp("Jump"))
                {

                    stopJump = true;
                    
                }
            }
            else
            {
                move.x = 0;

            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;

                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;

                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                        animator.SetBool("isFalling", false);
                     
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    animator.SetBool("isFalling", false);
                    
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                animator.SetBool("isJumping", true);
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                    animator.SetBool("isJumping", false);
                    

                }

            }
            else if (velocity.y < -0.1)
            {
                animator.SetBool("isFalling", true);

            }
            if (Mathf.Abs(velocity.y) < 0.1) 
            {
                animator.SetBool("isFalling", false);
            }


            if (move.x > 0.01f)
            {
                animator.SetBool("running", true);
                spriteRenderer.flipX = false;
            }
            else if (move.x < -0.01f)
            {
                animator.SetBool("running", true);
                spriteRenderer.flipX = true;
            }
            else
            {
                animator.SetBool("running", false);
              
            }

            animator.SetBool("grounded", IsGrounded);

            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Spike" && !hardmode)
            {
                spiked = true;
                TakeDamage(10);
                
            }

            if (other.gameObject.tag == "Enemy" && !hardmode)
            {
                TakeDamage(10);
            }
            if(other.gameObject.tag == "Enemy" && hardmode)
            {
                if (reversal)
                {
                    reversal = false;

                }
                else
                {
                    reversal = true;
                }
                TakeDamage(10);
            }

            if(other.gameObject.tag == "Spike" && hardmode)
            {
                if (reversal)
                {
                    reversal = false;

                }
                else
                {
                    reversal = true;
                }
                TakeDamage(10);
            }

            /*if (other.gameObject.tag == "MovingPlatform")
            {
                this.transform.parent = other.transform;
            }*/

        }

        bool robotSpiked() {
            return spiked;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            spiked = false;
        }


        void TakeDamage(int dmg)
        {
            ScreenShake.instance.StartShake(0.2f, 0.1f);
            currentHealth -= dmg;
            healthbar.SetHealth(currentHealth);
            //  red_screen.SetActive(true);
            if (currentHealth <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f; //pauses time
        }

        void ScreenShaking()
        {
            RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);

            if (rayHit.collider != null)
            {
                if (shakeCam)
                {
                    DamageObject(Camera.main.gameObject);
                }

                if (shakePlayer)
                {
                    DamageObject(rayHit.collider.gameObject);
                }
            }
        }

        private void DamageObject(GameObject dmgob)
        {
            dmgob.GetComponent<ControlShake>().ShakeMe();
        }

    }
}