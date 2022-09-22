using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager instance;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private Vector3 p1SpawnPoint;
    private Quaternion p1SpawnRot;
    private Vector3 p2SpawnPoint;
    private Quaternion p2SpawnRot;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public static RespawnManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        // Store the starting position and rotations of the players
        p1SpawnPoint = player1.transform.position;
        p1SpawnRot = player1.transform.rotation;
        p2SpawnPoint = player2.transform.position;
        p2SpawnRot = player2.transform.rotation;
    }
    
    public void RespawnPlayer(int playerIndex)
    {
        if (playerIndex == 1)
        {
            player1.transform.position = p1SpawnPoint;
            player1.transform.rotation = p1SpawnRot;
        }
        else if (playerIndex == 2)
        {
            player2.transform.position = p2SpawnPoint;
            player2.transform.rotation = p2SpawnRot;
        }
    }
}
