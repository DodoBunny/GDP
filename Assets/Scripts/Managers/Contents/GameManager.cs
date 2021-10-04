using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    public GameObject player;
    public Text scoreText;

    
    public int score = 0;

    public void Init()
    {

    }

    public void OnUpdate()
    {
        if(scoreText != null)
            scoreText.text = "Score : " + score;
    }

}
