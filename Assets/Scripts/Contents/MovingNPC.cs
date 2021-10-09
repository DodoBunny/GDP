using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNPC : MonoBehaviour
{
    public Transform startPos; // 플랫폼의 시작위치
    public Transform endPos; // 도착위치
    Transform desPos; // 목적지

    public float speed; // 플랫폼이 움직이는 속도

    void Start()
    {
        
        transform.position = startPos.position; // 처음 플랫폼의 위치는 = startPos의 포지션으로 초기화
        desPos = endPos; // 처음 목적지는 endPos로 초기화
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, speed * Time.deltaTime);
        // 플랫폼의 position은 현재 위치로부터 목적지의 위치로 speed의 값의 속도로 이동한다.

        if (Vector2.Distance(transform.position, desPos.position) <= 0.05f)
        // 플랫폼과 목적지 사이 거리가 0.05 이하이면..
        {
            if (desPos == endPos)
            // 목적지가 도착위치와 같아지면, 목적지를 시작위치로 바꿈
            {
                GetComponent<SpriteRenderer>().flipX = true;
                desPos = startPos;
            }
            else
            // 목적지가 시작위치와 같아지면, 목적지를 도착위치로 바꿈
            {
                GetComponent<SpriteRenderer>().flipX = false;
                desPos = endPos;
            }
        }
    }
}