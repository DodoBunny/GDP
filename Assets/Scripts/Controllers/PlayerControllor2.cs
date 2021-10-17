using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor2 : MonoBehaviour
{
    CapsuleCollider2D _collider;
    Rigidbody2D _rigid;
    Animator _anim;
    SpriteRenderer _sprite;
    AudioSource _audio; // 점프 효과음

    public bool canMove = true;

    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnim();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            float moveX = Managers.Input.horizontal;
            float moveY = Managers.Input.vertical;
            transform.position += new Vector3(moveX, moveY, 0).normalized * Time.deltaTime * moveSpeed;
        }

    }


    void SetAnim()
    {
        if (canMove)
        {
            if (Managers.Input.vertical != 0)
                _anim.SetBool("IsMove", true);

            if (Managers.Input.horizontal < 0)
            {
                _anim.SetBool("IsMove", true);
                _sprite.flipX = true;
            }
            else if (Managers.Input.horizontal > 0)
            {
                _anim.SetBool("IsMove", true);
                _sprite.flipX = false;
            }
            else if (Managers.Input.vertical != 0)
            {
                _anim.SetBool("IsMove", true);
            }
            else
            {
                _anim.SetBool("IsMove", false);
            }
        }
        else
        {
            _anim.SetBool("IsMove", false);
        }
    }


}
