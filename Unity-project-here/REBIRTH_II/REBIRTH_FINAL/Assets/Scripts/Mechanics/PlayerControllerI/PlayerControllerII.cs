/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerControllerII : MonoBehaviour
    {
        //public AudioClip jumpAudio;
       // public AudioClip respawnAudio;
      //  public AudioClip ouchAudio;
        public int maxHealth = 100;
        public int currentHealth = 100;
        private HealthBar healthbar;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        private JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        //internal new public Collider2D collider2d;
        //internal new public AudioSource audioSource;
        private Health health;
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
        public float timeLeft = 80.0f;
        public GameObject red_screen;

        public GameObject deathScreen;

       void Start()
        {
            //keyinv.SetActive(false);
           // mapinv.SetActive(false);
            //currentHealth = maxHealth;
            //healthbar.SetMaxHealth(maxHealth);
            //health = currentHealth;
            deathScreen.SetActive(false);
            red_screen.SetActive(false);

        }
        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

        }

        void Update()
        {

            if (controlEnabled)
            {
                if (hardmode)
                {
                    timeLeft -=Time.deltaTime;
                    if (timeLeft < 0)
                    {
                        Death();
                    }
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
                 
                    jumpState = JumpState.PrepareToJump;
                }

                if (isJumpReversed && jumpState == JumpState.Grounded && Input.GetButtonDown("JumpReversed"))
                {
                    animator.SetBool("running", false);
                    animator.SetTrigger("takeoff");
                 
                    jumpState = JumpState.PrepareToJump;
                }

                else if (Input.GetButtonUp("Jump"))
                {
                    
                    stopJump = true;
                    PlayerControllerII playerControllerII = this;
                    Schedule<PlayerStopJump>().player = playerControllerII;
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

        void ComputeVelocity()
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
                    animator.SetBool("isFalling", true);

                }

            }
            else if(velocity.y < 0)
            {
                animator.SetBool("isFalling", true);
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

            if(other.gameObject.tag == "Spike")
            {
                TakeDamage(10);
                Debug.Log(currentHealth);
            }

            if(other.gameObject.tag == "Enemy")
            {
                TakeDamage(10);
            }
        }

        void TakeDamage(int dmg)
        {
            currentHealth -= dmg;
            healthbar.SetHealth(currentHealth);
            red_screen.SetActive(true);
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
    }
}*/