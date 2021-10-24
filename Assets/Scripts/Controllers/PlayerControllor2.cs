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

    public bool canAttack = false;

    public GameObject Bullet;

    public float moveSpeed = 10f;

    float DelayTime;
    public float AttackSpeed = 0.3f;
    public bool isDead = false;

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
        if (GetComponent<Stat>().Hp <= 0)
        {
            _anim.SetTrigger("Die");
            isDead = true;
        }


        DelayTime += Time.deltaTime;
        SetAnim();
        if (!isDead)
            Attack();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!isDead)
        {
            float moveX = Managers.Input.horizontal;
            float moveY = Managers.Input.vertical;
            transform.position += new Vector3(moveX, moveY, 0).normalized * Time.deltaTime * moveSpeed;
        }

    }


    void SetAnim()
    {
        if (!isDead)
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

    void Attack()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (DelayTime > AttackSpeed)
            {
                float x = _sprite.flipX ? -0.5f : 0.5f;
                GameObject bullet = Instantiate(Bullet, transform.position + new Vector3(x, 0, 0), Quaternion.identity);
                bullet.GetComponent<WaterBullet>().flip = _sprite.flipX;
                DelayTime = 0f;
            }
        }
    }

}
