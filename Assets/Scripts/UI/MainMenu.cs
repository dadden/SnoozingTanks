using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playBtn;
    [SerializeField] private GameObject restartBtn;
    [SerializeField] private TextMeshProUGUI winText;

    private void Start()
    {
        
    }

    public void OnPlayBtnClicked()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene("PlayScene");
    }

}
