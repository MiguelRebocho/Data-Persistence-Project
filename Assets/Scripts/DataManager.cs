using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
