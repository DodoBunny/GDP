using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{

    public Define.Stage stage = Define.Stage.stage1;

    public bool stage1 = false;
    public GameObject player;
    public Text scoreText;

    //Scene2
    public float time = 60f;
    public int NPCcount = 0;
    public Text TimeText;
    public Text NPCCountText;
    public int NPCs = 0;


    public int score = 0;

    public void Init()
    {

    }

    public void OnUpdate()
    {
        switch (stage)
        {
            case Define.Stage.stage1:
                if (scoreText != null)
                    scoreText.text = "Score : " + score;
                break;
            case Define.Stage.stage2:
                if (time > 0)
                    time -= Time.deltaTime;
                TimeText.text = "남은 시간 : " + time.ToString("F1");
                NPCCountText.text = NPCcount + "명";
                break;
            case Define.Stage.stage3:
                if (time > 0)
                    time -= Time.deltaTime;
                TimeText.text = "남은 시간 : " + time.ToString("F1");
                break;
            case Define.Stage.stage4:
                break;

        }




    }

}
