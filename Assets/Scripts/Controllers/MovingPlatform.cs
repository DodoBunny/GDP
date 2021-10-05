using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPos; // 플랫폼의 시작위치
    public Transform endPos; // 도착위치
    public Transform desPos; // 목적지

    public float speed; // 플랫폼이 움직이는 속도

    void Start()
    {
        transform.position = startPos.position; // 처음 플랫폼의 위치는 = startPos의 포지션으로 초기화
        desPos = endPos; // 처음 목적지는 endPos로 초기화
    }

    void OnCollisionEnter2D(Collision2D collision)

    // 플랫폼이 tag가 "Player"인 것과 충돌하면, "Player"를 플랫폼의 자식관계로 만들어준다.
    // 자식관계가 되면, 부모의 position 값이 변경될 때 자식의 position 값도 동시에 변경된다.
    // (플랫폼 위에 플레이어가 올라가면 플랫폼만 움직이는 버그를 해결)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)

    // 플랫폼에서 플레이어가 나가면 자식관계를 끊는다.
    // (자식관계가 유지되어 플랫폼의 position 값 변경 플레이어에도 지속되는 버그를 해결)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
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
