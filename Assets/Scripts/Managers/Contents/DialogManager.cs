using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager
{
    public GameObject NPCPanel;
    public Text NPCText;
    public Image NPCSprite;

    public float DelayTime = 0f;

    public void NPCDialog(string text, Sprite NPC = null, bool canMove = true)
    {
        NPCPanel.SetActive(true);
        NPCText.text = text;
        if (NPC != null)
        {
            NPCSprite.sprite = NPC;
        }
        if (canMove == false)
            Managers.Game.player.GetComponent<PlayerController>().canMove = false;
        DelayTime = 0f;
    }
    public void OnUpdate()
    {
        DelayTime += Time.deltaTime;
        if (NPCPanel != null)
            DialogExit();
    }
    public void DialogExit()
    {
        if (DelayTime < 0.5f)
            return;

        if (Input.GetButtonDown("Interaction"))
        {
            NPCPanel.SetActive(false);
            Managers.Game.player.GetComponent<PlayerController>().canMove = true;
        }
    }

    public void DialogInactive()
    {
        NPCPanel.SetActive(false);
        Managers.Game.player.GetComponent<PlayerController>().canMove = true;
    }
}
