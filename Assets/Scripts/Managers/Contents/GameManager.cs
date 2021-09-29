using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    GameObject player;
    Text scoreText;

    public int score = 0;

    public void Init()
    {
        player = GameObject.Find("Player");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public void OnUpdate()
    {
        scoreText.text = "Score : " + score;
    }

}
