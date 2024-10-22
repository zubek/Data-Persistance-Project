using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    private void Awake()
    {

        if(Instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadNameAndScore();
    }


    [System.Serializable]
    class SaveData 
    {
        public string playerName;
        public int highScore;
        public string highScorePlaerName;
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();

        data.highScore = highScore;
        data.highScorePlaerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadNameAndScore() 
    {

        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path)) 
        { 
        
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlaerName;
            highScore = data.highScore;

        }
        else 
        {         
            playerName = null;
            highScore = 0;
        }

    }


}
