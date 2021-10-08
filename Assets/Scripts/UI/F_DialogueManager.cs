using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_DialogueManager : MonoBehaviour
{
    public GameObject DialoguePanel; // 판넬 오브젝트를 가져옴
    public Text Dialogue; // 텍스트 오브젝트

    public bool isAction; // Action 함수의 부울

    public void Action(string text)
    {
        if (isAction) // 판넬이 켜져있으면
        {
            isAction = false; // 판넬에 false값 준다
        }
        else // 판넬이 꺼져있으면
        {
            isAction = true; // 판넬에 true값 준다
            Dialogue.text = text;

        }

        DialoguePanel.SetActive(isAction); // 판넬의 부울값에 따라 판넬을 키고 끈다.
    }

}
