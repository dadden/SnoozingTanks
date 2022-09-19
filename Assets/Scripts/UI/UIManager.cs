using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI playerText;
    [SerializeField] private GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        // Todo: Make a function in TurnManager that returns current player, call it from here to get the hp of the correct player
        hpText.text = player.GetComponent<PlayerController>().GetHealth().ToString();
    }
}
