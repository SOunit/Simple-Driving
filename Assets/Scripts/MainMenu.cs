using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highScoreText;

    private void Start()
    {
        string highScore =
            PlayerPrefs.GetInt(ScoreSystem.HighScoreKey).ToString();
        highScoreText.text = $"High Score: {highScore}";
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
