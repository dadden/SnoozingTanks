using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    void Update()
    {
        transform.Rotate(0, +0.25f, 0, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddHP();
            Destroy(this.gameObject); 
        }
        
    }

    private void AddHP()
    {
        
    }
}
