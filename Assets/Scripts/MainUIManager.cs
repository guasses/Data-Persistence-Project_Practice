using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        if(Persistent.Instance != null)
        {
            if(Persistent.Instance.PlayerName == " ")
            {
                Persistent.Instance.PlayerName = Persistent.Instance.TempPlayerName;
            }
            SetBestScoreText(Persistent.Instance.PlayerName, Persistent.Instance.BestScore);
        }  
    }
    public void ReturnButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void SetBestScoreText(string name, int score)
    {
        bestScoreText.text = "Best Score : " + name + " : " + score;
    }
}
