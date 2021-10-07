using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBoxController : MonoBehaviour
{
    public Transform startPos; // 시작위치
    public Transform endPos; // 도착위치
    public Transform desPos; // 목적지

    public float speed; // 움직이는 속도

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position; // 처음 위치는 = startPos의 포지션으로 초기화
        desPos = endPos; // 처음 목적지는 endPos로 초기화

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, speed * Time.deltaTime);
        // position은 현재 위치로부터 목적지의 위치로 speed의 값의 속도로 이동한다.

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        // 목적지 사이 거리가 0.05 이하이면..
        {
            if (desPos == endPos)
            // 목적지가 도착위치와 같아지면, 목적지를 시작위치로 바꿈
            {
                desPos = startPos;
            }
            else
            // 목적지가 시작위치와 같아지면, 목적지를 도착위치로 바꿈
            {
                desPos = endPos;
            }
        }

    }

}
