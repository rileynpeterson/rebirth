using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public class ContinuousJump : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

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
        public Image healthBar;


        public GameObject deathScreen;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;
        public int maxHealth = 100;
        public int currentHealth = 100;

        private bool shakeCam;
        private bool shakePlayer;

        protected override void Start()
        {
            currentHealth = maxHealth;
            //healthBar.SetMaxHealth(maxHealth);
            healthBar.fillAmount = maxHealth;
            deathScreen.SetActive(false);
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
                move.x = Input.GetAxis("Horizontal");
                animator.SetBool("run", true);
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    animator.SetBool("run", true);
                animator.SetTrigger("takeoff");
                jumpState = JumpState.PrepareToJump;
                animator.SetBool("jump", true);
            }
            else if (Input.GetButtonUp("Jump"))
            {
                stopJump = true;
               // Schedule<PlayerStopJump>().player = this;
            }
            else
            {
                move.x = 0;
                animator.SetBool("run", false);
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
                        //Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                       // Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                        animator.SetBool("jump", false);
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

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

            if (other.gameObject.tag == "Spike")
            {
                TakeDamage(10);
                Debug.Log(currentHealth);
            }

            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(10);
            }
        }

        void TakeDamage(int dmg)
        {
            currentHealth -= dmg;
            healthBar.fillAmount = currentHealth;
            if (currentHealth <= 0)
            {
                Death();
            }
        }

        void Death()
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
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