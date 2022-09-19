using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private bool isActive;
    [SerializeField] private float upMomentum = 200f;
    [SerializeField] private float forwardMomentum = 800f;
    
    public void Fire()
    {
        isActive = true;
        // Adds force to projectile, moving it up slightly as well as forward
        rb.AddForce(transform.forward * forwardMomentum + transform.up * upMomentum, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Apply a small impulse on the hit player/enemy, then call the TakeDamage function
        GameObject hitObject = collision.gameObject;
        if (hitObject.CompareTag("Player"))
        {
            hitObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 100);
            hitObject.GetComponent<PlayerController>().TakeDamage(2);
            Destroy(this.gameObject);
            Debug.Log("Projectile hit player");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
