using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (Managers.Game.player.GetComponent<PlayerController>().canMove == false)
            return;

        float x = Managers.Input.horizontal * moveSpeed * -1;
        Vector3 dir = new Vector3(x, 0, 0);
        transform.position += dir;
    }
}
