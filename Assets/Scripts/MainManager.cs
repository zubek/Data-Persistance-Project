using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    //public Rigidbody Ball;

    public int HighScore;

    private Text ScoreText;
    private GameObject GameOverText;
    private GameObject HighScoreText;
    private Rigidbody Ball;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public static MainManager Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_GameOver = false;
                m_Started = false;
                m_Points = 0;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void StartGame() 
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        GameOverText = GameObject.Find("GameoverText");
        HighScoreText = GameObject.Find("HighScoreText");
        Ball = GameObject.Find("Ball").GetComponent<Rigidbody>();
        GameOverText.SetActive(false);

        LoadHighScore();

        if (HighScore == 0)
        {
            HighScoreText.SetActive(false);
        }
        else
        {
            Text h_text = HighScoreText.GetComponent<Text>();
            h_text.text = "HighScore: " + HighScore;
            HighScoreText.SetActive(true);
        }

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    public void MenuGame() 
    {

        HighScoreText = GameObject.Find("HighScoreText");

        LoadHighScore();

        if (HighScore == 0)
        {
            HighScoreText.SetActive(false);
        }
        else
        {
            Text h_text = HighScoreText.GetComponent<Text>();
            h_text.text = "HighScore: " + HighScore;
            HighScoreText.SetActive(true);
        }

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        HighScore = m_Points;
        SaveHighScore();
    }

    [System.Serializable]
    class SaveData
    { 
        public int HighScore;
    }

    public void SaveHighScore() 
    { 
        SaveData data = new SaveData();
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
        }
        else
        {
            HighScore = 0;
        }
    }

}
