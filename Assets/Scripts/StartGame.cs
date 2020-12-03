using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    int bestScore;
    public Text textBestScore;
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt ("bestScore");
        textBestScore.text = $"лучший результат: {bestScore}";
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
