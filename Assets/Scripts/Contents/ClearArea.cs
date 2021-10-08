using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearArea : MonoBehaviour
{
    public string targetScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 충돌");
        if(collision.gameObject == Managers.Game.player)
        {
            GameObject.Find("@Scene").GetComponent<GameScene>().StartFadeIn();
            Invoke("LoadScene",4f);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(targetScene);
    }

}
