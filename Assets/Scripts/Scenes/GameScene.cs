using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public Define.Stage stage = Define.Stage.stage1;

    public Image fadeinImg;
    public Text fadeinText;

    public Image fadeoutImg;
    public Text fadeoutText;

    public GameObject NPC_UI;
    public Text NPC_Text;
    public Image NPC_Sprite;


    //Scene2
    public Text TimeText;
    public Text NPCCountText;
    public bool timeOut = false;


    private void Awake()
    {
        Managers.Game.stage = this.stage;
        Managers.Game.player = GameObject.Find("Player");
        switch (stage)
        {
            case Define.Stage.stage1:
                Managers.Game.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
                Managers.Dialog.NPCPanel = NPC_UI;
                Managers.Dialog.NPCText = NPC_Text;
                Managers.Dialog.NPCSprite = NPC_Sprite;
                break;
            case Define.Stage.stage2:
                Managers.Game.TimeText = this.TimeText;
                Managers.Game.NPCCountText = this.NPCCountText;
                break;
            case Define.Stage.stage3:
                Managers.Game.TimeText = this.TimeText;
                break;
            case Define.Stage.stage4:
                break;

        }
        StartCoroutine(FadeOut());
        timeOut = false;
        Managers.Game.time = 60f;
    }

    private void Update()
    {
        switch (stage)
        {
            case Define.Stage.stage1:
                break;
            case Define.Stage.stage2:
                if (Managers.Game.time <= 0 && !timeOut)
                {
                    Managers.Game.score += Managers.Game.NPCcount * 10;
                    StartFadeIn();
                    timeOut = true;
                    Invoke("Scene2Clear", 4f);
                }
                break;
            case Define.Stage.stage3:
                if (Managers.Game.time <= 0 && !timeOut)
                {
                    StartFadeIn();
                    timeOut = true;
                    Invoke("Scene3Clear", 4f);
                }
                break;
            case Define.Stage.stage4:
                break;

        }
    }


    public void StartFadeIn()
    {
        fadeinImg.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.005f;
            yield return new WaitForSeconds(0.01f);
            fadeinImg.color = new Color(0, 0, 0, fadeCount);
            fadeinText.color = new Color(255, 255, 255, fadeCount);
        }
    }

    IEnumerator FadeOut()
    {
        float fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.005f;
            yield return new WaitForSeconds(0.01f);
            fadeoutImg.color = new Color(0, 0, 0, fadeCount);
            fadeoutText.color = new Color(255, 255, 255, fadeCount);
        }
        Destroy(fadeoutImg.gameObject);
    }

    void Scene2Clear()
    {
        SceneManager.LoadScene("Stage 3");
    }
    void Scene3Clear()
    {
        SceneManager.LoadScene("Stage 4");
    }

}
