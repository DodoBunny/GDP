using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    BoxCollider2D isTrigger;
    public PlayerController player; // 플레이어 컨트롤러 퍼블릭으로 가져다가 씀
    public GameObject talkBox;

    // Start is called before the first frame update
    void Start()
    {
        isTrigger = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interaction") && player.scanObject != null) //player.scanObject.tag == "Dialogue"
        {
            isTrigger.isTrigger = true;
            talkBox.SetActive(false);
        }

    }
}
