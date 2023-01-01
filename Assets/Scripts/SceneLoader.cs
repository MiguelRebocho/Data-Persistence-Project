using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public InputField nameInput;
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = " Best Score: " + DataManager.Instance.highScorePlayerName + " : " + DataManager.Instance.highScore;
    }

    public void LoadMainScene()
    {
        DataManager.Instance.playerName = nameInput.text;

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
