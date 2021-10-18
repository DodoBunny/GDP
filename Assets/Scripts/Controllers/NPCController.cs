using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator _anim;
    SpriteRenderer _sprite;

    public float sight = 10f;
    public float speed = 3f;

    bool targetLock = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Managers.Game.player.transform.position.y == transform.position.y)
            targetLock = true;
        else
            targetLock = false;

        if (!targetLock)
        {
            if (Mathf.Abs((Managers.Game.player.transform.position - transform.position).magnitude) < sight)
            {
                _anim.SetBool("IsMove", true);
                Vector3 dir = -(transform.position - Managers.Game.player.transform.position).normalized;
                transform.position += dir * speed * Time.deltaTime;
            }
            else
            {
                _anim.SetBool("IsMove", false);
            }
        }


        if (transform.position.x > Managers.Game.player.transform.position.x)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }

    }

    void Patrol()
    {

    }

}
