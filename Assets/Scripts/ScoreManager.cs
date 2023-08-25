using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string currentName;
    public string bestScoreName;
    public int bestScore = 0;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void setCurrentName(string name)
    {
        currentName = name;
    }

    [System.Serializable]
    class ScoreData
    {
        public string name;
        public int score;
    }

    public void SaveBestScore()
    {
        ScoreData data = new ScoreData();
        data.name = currentName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";

        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            bestScoreName = data.name;
            bestScore = data.score;
        }
    }
}
