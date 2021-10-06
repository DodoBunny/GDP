using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialoguePanel; // 판넬 오브젝트를 가져옴
    public Text Dialogue; // 텍스트 오브젝트

    public GameObject scanObject; // 스캔 오브젝트
    public bool isAction; // Action 함수의 부울

    public void Action(GameObject scanObj)
    {
        if(isAction) // 판넬이 켜져있으면
        {
            isAction = false; // 판넬에 false값 준다
        }
        else // 판넬이 꺼져있으면
        {
            isAction = true; // 판넬에 true값 준다
            Dialogue.text = "안녕! 가천대학교에 온걸 환영해"; // 텍스트를 넣어준다
            //scanObject = scanObj;

        }

        DialoguePanel.SetActive(isAction); // 판넬의 부울값에 따라 판넬을 키고 끈다.
    }

}


