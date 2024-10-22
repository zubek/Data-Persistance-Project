using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;
    public bool isPlayerNameValidate = false;

    private void Awake()
    {

        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    public void LoadMainScene()
    {
        if (isPlayerNameValidate) 
        { 
            SceneManager.LoadScene(1);        
        }
    }

    public void LoadMenuScene() 
    {
        SceneManager.LoadScene(0);
    }

}
