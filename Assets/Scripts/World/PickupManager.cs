using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField] private GameObject prefabToSpawn;

    // Destroy instance if one already exists in the world
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PickupManager GetInstance()
    {
        return instance;
    }

    // Spawns a health pack in a random location from array
    public void SpawnHealth()
    {
        
    }
}
