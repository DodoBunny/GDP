using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator _anim;
    SpriteRenderer _sprite;
    RaycastHit2D hit;

    public float sight = 6f;
    public float speed = 3f;

    bool targetLock = false;
    Vector3 patrolDir;
    enum State
    {
        Patrol,
        Follow,
        Attack
    }
    State state = State.Patrol;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("RandomPos", 0, Random.Range(3f, 7f));
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        if (!targetLock)
        {
            if (Mathf.Abs((Managers.Game.player.transform.position - transform.position).magnitude) < sight)
            {
                if (hit.collider == null)
                    state = State.Follow;
                else
                    state = State.Attack;
            }
            else
            {
                state = State.Patrol;
            }
        }

        switch (state)
        {
            case State.Patrol:
                _anim.SetBool("IsMove", true);
                if (patrolDir.x < 0)
                {
                    _sprite.flipX = true;
                }
                else
                {
                    _sprite.flipX = false;
                }
                transform.position += patrolDir * speed * Time.deltaTime;
                break;
            case State.Follow:
                _anim.SetBool("IsMove", true);
                if (transform.position.x > Managers.Game.player.transform.position.x)
                {
                    _sprite.flipX = true;
                }
                else
                {
                    _sprite.flipX = false;
                }
                Vector3 dir = -(transform.position - Managers.Game.player.transform.position).normalized;
                transform.position += dir * speed * Time.deltaTime;
                break;
            case State.Attack:
                _anim.SetBool("IsMove", false);
                break;
        }


    }

    void Ray()
    {
        Vector3 Dir = transform.position.x > Managers.Game.player.transform.position.x ? Vector3.left : Vector3.right;

        Debug.DrawRay(transform.position, Dir);
        hit = Physics2D.Raycast(transform.position, Dir, 6f, LayerMask.GetMask("Player"));
    }

    void RandomPos()
    {
        Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0).normalized;
        patrolDir = dir;
    }

}
