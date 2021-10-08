using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public PlayerController player; // 플레이어 컨트롤러 퍼블릭으로 가져다가 씀
    public GameObject talkBox;
    public BoxCollider2D coll;
    public GameObject scanObject;

    private void OnCollisionStay2D(Collision2D collision)
    {
        scanObject = player.scanObject;
        
        coll = scanObject.GetComponent<BoxCollider2D>();
        talkBox = scanObject.transform.GetChild(0).gameObject;

        if (Input.GetButtonDown("Interaction") && scanObject != null)
        {

            coll.isTrigger = true;
            talkBox.SetActive(false); // SetActive는 오브젝트 키고 끄기

        }

    }
}
