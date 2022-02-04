using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class StartMenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        Persistent.Instance.LoadData();
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene(1);
        Persistent.Instance.TempPlayerName = playerNameText.text;
    }

    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
