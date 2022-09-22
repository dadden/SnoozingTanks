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
        RespawnManager.GetInstance().RespawnPlayer(hitObject.GetComponent<PlayerController>().GetIndex());
    }
}
