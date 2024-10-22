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


    // Start is called before the first frame update
    void Start()
    {

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
            LevelManager.Instance.LoadMainScene();
        }
    }

}
