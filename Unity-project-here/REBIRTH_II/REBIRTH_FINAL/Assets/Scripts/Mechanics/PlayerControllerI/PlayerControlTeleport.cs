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
 public class PlayerControlTeleport : MonoBehaviour
 {
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        public int maxHealth = 100;
        public int currentHealth = 100;
        public HealthBar healthbar;

        public Collider2D collider2d;
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;
        public Image healthBar;
        public GameObject deathScreen;
        private bool shakeCam;
        private bool shakePlayer;
  
    /*public void Teleport(Transform tp_trans)
    {
        Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        new_pos.z = tp_trans.position.z;
        tp_trans.position = new_pos;
    }*/
    //Set up a variable to access the player from
        private Transform player;

      void Start()
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
        //Find the player object and set it
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
        collider2d = GetComponent<Collider2D>();
    }
 
    void Update()
    {
        // Check if you click the left mouse button then change position
        if (Input.GetMouseButtonDown(0))
        player.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
 