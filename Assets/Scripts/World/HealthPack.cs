using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void Update()
    {
        // Spins around on the y axis continuously
        transform.Rotate(0, +0.25f, 0, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (collision.gameObject.tag == "Player");
        {
            // Produces a random value from 5-10, calls the AddHP function, then destroys itself
            AddHP(hitObject, UnityEngine.Random.Range(5, 10));
            Destroy(this.gameObject); 
        }
        
    }

    private void AddHP(GameObject hitObj, int amount)
    {
        hitObj.GetComponent<PlayerController>().AddHP(amount);
    }
}
