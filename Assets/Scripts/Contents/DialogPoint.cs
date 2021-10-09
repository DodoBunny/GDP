using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPoint : MonoBehaviour
{
    public bool autoDialog = false;

    public string text = "텍스트를 입력하시오";
    public Sprite NPC;
    public bool isDestroy = false;
    public bool canMove = false;

    public GameObject talkSprite;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (autoDialog == false)
            return;

        if(collision.gameObject == Managers.Game.player)
        {
            Managers.Dialog.NPCDialog(text, NPC, canMove);
            if (isDestroy)
                Destroy(gameObject);
            if (talkSprite != null)
                Destroy(talkSprite);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (autoDialog == true)
            return;

        if (collision.gameObject == Managers.Game.player && Input.GetButtonDown("Interaction"))
        {
            Managers.Dialog.NPCDialog(text, NPC, canMove);
            if (isDestroy)
                Destroy(gameObject);
            if(talkSprite != null)
                Destroy(talkSprite);
        }
    }
}
