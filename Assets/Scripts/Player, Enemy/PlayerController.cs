using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        [SerializeField] private Rigidbody characterBody;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float jumpSpeed = 50f;
        [SerializeField] private int playerIndex;
        [SerializeField] private GameObject particle;
        [SerializeField] private Camera followCamera;

        private int health = 100;
        private int hitPoints = 0;

        private void Start()
        {
            // Hide the cursor and disable the particle system
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


                if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor()) 
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

        }
    
        private void Jump()
        {
            characterBody.AddForce(Vector3.up * jumpSpeed);
        }
    
        private bool IsTouchingFloor()
        {
            RaycastHit hit;
            bool result =  Physics.SphereCast(transform.position, 0.85f, -transform.up, out hit, 2f);
            return result;
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
