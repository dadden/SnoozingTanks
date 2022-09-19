using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float jumpSpeed = 50f;
        [SerializeField] private int playerIndex;

        private int health = 100;
        private int hitPoints = 0;

        public void TakeDamage(int amount)
        {
            health = health - amount;
            Debug.LogError("Took damage! New health: " + health);
        }

        public void AddHitPoint()
        {
            hitPoints++;
            Debug.Log("Added hitpoint! Total hitpoints: " + hitPoints);
        }
}
