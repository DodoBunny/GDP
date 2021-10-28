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
    Exit
}


public class LobbyScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNTpye currentType; // enum
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    bool isSound;
    public Text text;


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
                break;

            case BTNTpye.Option:
                Debug.Log("옵션");
                OnCanvasGroupChanged(optionGroup);
                OffCanvasGroupChanged(mainGroup);
                break;

            case BTNTpye.Sound:
                if(isSound)
                {
                    Debug.Log("사운드 OFF");
                    text.text = "사운드 OFF";
                }
                else
                {
                    Debug.Log("사운드 ON");
                    text.text = "사운드 ON";
                }

                isSound = !isSound;
                //Managers.Sound.BGM_clip
                break;

            case BTNTpye.Back:
                Debug.Log("뒤로");
                OnCanvasGroupChanged(mainGroup);
                OffCanvasGroupChanged(optionGroup);
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
