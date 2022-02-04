using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Persistent : MonoBehaviour
{
    public static Persistent Instance;
    public string TempPlayerName;
    public string PlayerName;
    public int BestScore;
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        this.TempPlayerName = " ";
        this.PlayerName = " ";
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class PlayerData
    {
        public string PlayerName;
        public int BestScore;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.PlayerName = PlayerName;
        data.BestScore = BestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            PlayerName = data.PlayerName;
            BestScore = data.BestScore;
        }
    }
}
