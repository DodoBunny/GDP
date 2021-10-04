using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    private void Awake()
    {
        Managers.Game.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Managers.Game.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }



}
