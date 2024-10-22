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
        Debug.Log(inputNameText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextInputValidation() 
    {
        string playerName = inputNameText.text;
        if (playerName == "")
        {
            validationMessage.gameObject.SetActive(true);
        }
        else
        {
            validationMessage.gameObject.SetActive(false);
        }
    }

    public void DebugInput() 
    {
        string playerName = inputNameText.text;
        
        if(playerName == "") 
        {
            validationMessage.gameObject.SetActive(true);
            Debug.Log("Required enter name");
        }
        else 
        { 
            Debug.Log(inputNameText.text);        
        }
    }
}
