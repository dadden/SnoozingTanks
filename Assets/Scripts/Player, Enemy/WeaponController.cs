using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject player;
    private int playerIndex;
    private float maxRotation = 10f;
    private float minRotation = -30f;
    private float rotationZ = 0f;

    private void Start()
    {
        playerIndex = player.GetComponent<PlayerController>().GetIndex();
    }

    private void Update()
    {
        if (TurnManager.GetInstance().IsItMyTurn(playerIndex))
        {

            rotatePipe();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Spawn projectile and call its Fire() function
            GameObject newProjectile = Instantiate(projectilePrefab);
            // Add 2 to z location to eliminate chances of colliding with the weapon itself
            newProjectile.transform.position = new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z + 2);
            newProjectile.GetComponent<Projectile>().Fire();
        }
    }

    
    }  
    
    private void rotatePipe()
    { 
        // Get mouse Y and multiply by -1 to invert the direction
        rotationZ += Input.GetAxis("Mouse Y") * 2 * -1;
        // Clamp the rotation between two points (prevents helicopter functionality)
        rotationZ = Mathf.Clamp(rotationZ, minRotation, maxRotation);
        // Finally, set the world rotation to the clamped value
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);
    }
}
