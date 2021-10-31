using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum BTNTpye // 열거형
{
    Start,
    Score,
    Option,
    Sound,
    Back,
    Back2,
    Exit
}


public class LobbyScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNTpye currentType; // enum
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup scoreGroup;
    bool isSound;
    public Text text;
    public Text sText;
    public ClearText cleartext;
    public AudioSource BGM;
    public AudioSource Item;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
        isSound = true;
    }


    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNTpye.Start:
                Debug.Log("게임 시작");
                SceneManager.LoadScene("Stage 1 - 1");
                break;

            case BTNTpye.Score:
                Debug.Log("점수");
                //scoreBox.SetActive(true);
                if (PlayerPrefs.HasKey("Score"))
                {
                    sText.text = "High Score : " + PlayerPrefs.GetInt("Score").ToString();
                }
                else
                {
                    sText.text = "기록이 없습니다";
                }
                OnCanvasGroupChanged(scoreGroup);
                OffCanvasGroupChanged(mainGroup);

                break;

            case BTNTpye.Option:
                Debug.Log("옵션");
                OnCanvasGroupChanged(optionGroup);
                OffCanvasGroupChanged(mainGroup);
                break;

            case BTNTpye.Sound:
                if (isSound)
                {
                    GameObject.Find("BGM").GetComponent<AudioSource>().volume = 0f;
                    Managers.Sound.BGM.volume = 0f;
                    Managers.Sound.Item.volume = 0f;
                    text.text = "사운드 OFF";
                }
                else
                {
                    GameObject.Find("BGM").GetComponent<AudioSource>().volume = 1.2f;
                    Managers.Sound.BGM.volume = 0.2f;
                    Managers.Sound.Item.volume = 0.2f;
                    text.text = "사운드 ON";
                }

                isSound = !isSound;
                break;

            case BTNTpye.Back:
                Debug.Log("뒤로");
                OnCanvasGroupChanged(mainGroup);
                OffCanvasGroupChanged(optionGroup);
                break;

            case BTNTpye.Back2:
                Debug.Log("뒤로2");
                OnCanvasGroupChanged(mainGroup);
                OffCanvasGroupChanged(scoreGroup);
                break;

            case BTNTpye.Exit:
                Debug.Log("게임 종료");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit();
                break;




        }

    }

    public void OnCanvasGroupChanged(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }


    public void OffCanvasGroupChanged(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
