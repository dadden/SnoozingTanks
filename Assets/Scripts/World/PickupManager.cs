using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupManager : MonoBehaviour
{
    private static PickupManager instance;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private List<Transform> hpSpawnLocations;

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

    // Moves a health pack to a random location from array
    public void MoveHealthPack(GameObject hpPack)
    {
        int randomNum = Random.Range(0, hpSpawnLocations.Count);
        hpPack.transform.position = hpSpawnLocations[randomNum].position;
    }
}
