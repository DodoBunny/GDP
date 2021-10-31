using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Text highScore;
    public Text Score;

    void Start()
    {
        Score.text = "Score : " + Managers.Game.score.ToString();

        if (PlayerPrefs.HasKey("Score"))
        {
            if (PlayerPrefs.GetInt("Score") < Managers.Game.score)
            {
                PlayerPrefs.SetInt("Score", Managers.Game.score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Score", Managers.Game.score);
        }

        highScore.text = "High Score : " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
