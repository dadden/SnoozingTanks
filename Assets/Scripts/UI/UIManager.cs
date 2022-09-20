using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start()
    {
        playerText.text = "Blueberry";
    }

    void Update()
    {
        // Gets the currentTime from TurnManager and floors it to sanitize decimals
        float sanitizedTimer = Mathf.FloorToInt(TurnManager.GetInstance().GetCurrentTime());
        timerText.text = sanitizedTimer.ToString();

        // Gets the health from player and floors it to sanitize decimals
        if (TurnManager.GetInstance().GetPlayerTurn() == 1)
        {
            float sanitizedHp = Mathf.FloorToInt(player1.GetComponent<PlayerController>().GetHealth());
            hpText.text = "HP: " + sanitizedHp.ToString();
        }
        else if (TurnManager.GetInstance().GetPlayerTurn() == 2)
        {
            float sanitizedHp = Mathf.FloorToInt(player2.GetComponent<PlayerController>().GetHealth());
            hpText.text = "HP: " + sanitizedHp.ToString();
        }
    }

    public void UpdateDisplayedPlayer()
    {
        if (playerText.text == "Blueberry")
        {
            playerText.text = "Strawberry";
        }
        else if (playerText.text == "Strawberry")
        {
            playerText.text = "Blueberry";
        }
    }
}
