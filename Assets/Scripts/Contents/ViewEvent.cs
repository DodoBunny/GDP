using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEvent : MonoBehaviour
{
    public Vector3 target;
    public float speed = 20f;
    public float resetTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Managers.Game.player)
        {
            Camera.main.GetComponent<MoveCam>().CameraMoveToTarget(target, speed, resetTime);
            Destroy(gameObject);
        }
    }
}
