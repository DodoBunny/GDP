using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public Image fadeinImg;
    public Text fadeinText;

    public Image fadeoutImg;
    public Text fadeoutText;

    private void Awake()
    {
        Managers.Game.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        Managers.Game.player = GameObject.Find("Player");

        StartCoroutine(FadeOut());
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


}
