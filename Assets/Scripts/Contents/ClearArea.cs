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
            SceneManager.LoadScene(targetScene);
        }
    }

}
