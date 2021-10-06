using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public Image fade;
    public Text text;

    private void Awake()
    {
        Managers.Game.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Managers.Game.player = GameObject.Find("Player");
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
        }
    }

    IEnumerator FadeOut()
    {
        float fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.005f;
            yield return new WaitForSeconds(0.01f);
            fade.color = new Color(0, 0, 0, fadeCount);
            text.color = new Color(255, 255, 255, fadeCount);
        }
        Destroy(fade.gameObject);
    }


}
