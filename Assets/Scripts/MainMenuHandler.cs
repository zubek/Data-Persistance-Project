using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuHandler : MonoBehaviour
{

    public TMP_InputField inputNameText;
    public TMP_Text validationMessage;
    public GameObject highScoreTextObject;


    // Start is called before the first frame update
    void Start()
    {

        if(ScoreManager.Instance.playerName == null) 
        {         
            highScoreTextObject.SetActive(false);
        }
        else 
        { 
            Text hs_text = highScoreTextObject.GetComponent<Text>();
            hs_text.text = "Best Score : " + ScoreManager.Instance.highScorePlayerName + " : " + ScoreManager.Instance.highScore;
        }

    }

    public void TextInputValidation() 
    {
        string playerName = inputNameText.text;
        if (playerName == "")
        {
            validationMessage.gameObject.SetActive(true);
            LevelManager.Instance.isPlayerNameValidate = false;
        }
        else
        {
            validationMessage.gameObject.SetActive(false);
            LevelManager.Instance.isPlayerNameValidate = true;
        }
    }

    public void StartGame() 
    {
        
        string playerName = inputNameText.text;

        if (playerName == "")
        {
            validationMessage.gameObject.SetActive(true);
            LevelManager.Instance.isPlayerNameValidate = false;
        }
        else
        {
            LevelManager.Instance.isPlayerNameValidate = true;
            ScoreManager.Instance.playerName = playerName;
            LevelManager.Instance.LoadMainScene();
        }
    }

}
