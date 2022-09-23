using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        // Get the index from the player, pass it to the respawn manager
        RespawnManager.GetInstance().RespawnPlayer(hitObject.GetComponent<PlayerController>().GetIndex());
      
    }
}
