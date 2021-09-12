using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    /*

        TODO : 키 입력을 저장하는 변수 선언

    */
    public float horizontal;
    public float vertical;

    public void OnUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }

    public void Clear()
    {
        //변수 초기화
    }
}
