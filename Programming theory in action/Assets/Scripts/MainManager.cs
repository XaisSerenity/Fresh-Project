using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string playerName;
    public int playerHighScore;
    public string topScorerName;
    public int topScore;
    public string lastPlayer;
    public bool topScorer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerHighScore;
        public string topScorerName;
        public int topScore;
        public string lastPlayer;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile" + playerName + ".json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile" + playerName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
        }
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerHighScore = playerHighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile" + playerName + ".json", json);
    }
    public void SaveTopScorer()
    {
        SaveData data = new SaveData();
        data.topScore = topScore;
        data.topScorerName = topScorerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefiletopscore.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile" + playerName + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerHighScore = data.playerHighScore;
        }
    }
    public void LoadTopScorer()
    {
        string path = Application.persistentDataPath + "/savefiletopscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topScore = data.topScore;
            topScorerName = data.topScorerName;
            topScorer = true;
        }
        else
        {
            topScorer = false;
        }
    }
    public void SaveLastPlayerPlayed()
    {
        SaveData data = new SaveData();
        data.lastPlayer = lastPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefilelastplayer.json", json);
    }
    public void LoadLastPlayerPlayed()
    {
       
        string path = Application.persistentDataPath + "/savefilelastplayer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            lastPlayer = data.lastPlayer;
        }
    }
}
