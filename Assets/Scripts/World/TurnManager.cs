using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private float turnTimer;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    private float currentTurnTime;
    private float turnTimeLimit = 15f;

    private int currentPlayer;

    // If no other instance exists, set reference to self and set player turn
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayer = 1;
        }
    }
    
    // Used to reference functions of this script in others
    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayer == 1)
        {
            currentPlayer = 2;
            camera1.SetActive(false);
            camera2.SetActive(true);
            Debug.Log("Changed turn to player 2");
        }
        else if (currentPlayer == 2)
        {
            currentPlayer = 1;
            camera2.SetActive(false);
            camera1.SetActive(true);
            Debug.Log("Changed turn to player 1");
        }
    }

    // Used by the player controller to check who's turn it is
    public bool IsItMyTurn(int index)
    {
        if (index == currentPlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeTurn();
        }

        currentTurnTime += Time.deltaTime;
        if (currentTurnTime >= turnTimeLimit)
        {
            ChangeTurn();
            currentTurnTime = 0;
        }
    }
}
