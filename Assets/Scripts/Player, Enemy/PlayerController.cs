using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private Rigidbody characterBody;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float jumpSpeed = 500f;
        [SerializeField] private int playerIndex;
        [SerializeField] private GameObject particle;
        private bool isGrounded;

        private int health = 100;
        private int hitPoints = 0;

        private void Start()
        {
            // Hide the cursor

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;

        }

        void Update()
        {
            // Only update if its my turn
            if (TurnManager.GetInstance().IsItMyTurn(playerIndex))
            {
                particle.SetActive(false);
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                if (moveHorizontal != 0) 
                {
                    //transform.Translate(transform.right * moveSpeed * Time.deltaTime * moveHorizontal, Space.World); 
                    transform.Rotate(transform.up * moveSpeed * 10 * Time.deltaTime * moveHorizontal, Space.World); 
                }
                if (moveVertical != 0) 
                {
                    transform.Translate(transform.forward * moveSpeed * Time.deltaTime * moveVertical, Space.World); 
                }
                
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) 
                {
                    Jump();
                }
                
            }
            else
            {
                particle.SetActive(true);
            }

            // Very janky code to prevent players from ending up upside down with no way to get up again
            if (transform.eulerAngles.z <= 60 || transform.eulerAngles.z >= 60)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
            
            // Hardcoded way of advancing to the correct game over screen :)
            if (playerIndex == 1 && health == 0)
            {
                SceneManager.LoadScene("GameOver_P1");
            }
            else if (playerIndex == 2 && health == 0)
            {
                SceneManager.LoadScene("GameOver_P2");
            }

        }
    
        private void Jump()
        {
            characterBody.AddForce(Vector3.up * jumpSpeed);
        }

        private void OnCollisionStay(Collision collisionInfo)
        {
            isGrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            isGrounded = false;
        }

        public void TakeDamage(int amount)
        {
            health = health - amount;
            if (health < 0)
            {
                health = 0;
            }
            Debug.LogError("Took damage! New health: " + health);
        }
        
        public void AddHP(int amount)
        {
            health = health + amount;
            if (health > 100)
            {
                health = 100;
            }
            Debug.LogError("Picked up HP! New health: " + health);
        }

        public void AddHitPoint()
        {
            hitPoints++;
            Debug.Log("Added hitpoint! Total hitpoints: " + hitPoints);
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetIndex()
        {
            return playerIndex;
        }
}
