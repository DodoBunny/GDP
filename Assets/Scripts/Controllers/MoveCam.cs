using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public bool active = true;

    public Transform target;
    public float _speed = 10;

    Vector3 eventTarget;
    float eventSpeed;

    float height;
    float width;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void LateUpdate()
    {
        if (active)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * _speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, eventTarget, Time.deltaTime * eventSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }

    public void CameraMoveToTarget(Vector3 pos, float speed, float resetTime)
    {
        active = false;
        Managers.Game.player.GetComponent<PlayerController>().canMove = false;
        this.eventTarget = pos;
        this.eventSpeed = speed;
        Invoke("ReActive", resetTime);
    }

    void ReActive()
    {
        Managers.Game.player.GetComponent<PlayerController>().canMove = true;
        active = true;
    }


}
