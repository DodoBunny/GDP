using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CapsuleCollider2D _collider;
    Rigidbody2D _rigid;
    Animator _anim;
    SpriteRenderer _sprite;
    AudioSource _audio; // 점프 효과음

    public float moveSpeed = 10f;
    public float jumpPower = 20f;
    public float maxSpeed = 20f;

    [SerializeField]
    private bool isGrounded = false;


    private void Awake()
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
        Jump();
        SetAnim();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rigid.AddForce(Vector2.right * Managers.Input.horizontal * moveSpeed, ForceMode2D.Impulse);

        if (_rigid.velocity.x > maxSpeed)
            _rigid.velocity = new Vector2(maxSpeed, _rigid.velocity.y);
        else if (_rigid.velocity.x < maxSpeed * (-1))
            _rigid.velocity = new Vector2(maxSpeed * (-1), _rigid.velocity.y);

    }

    void Jump()
    {
        if (!isGrounded)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _audio.Play(); // 점프 효과음 재생
            _anim.SetTrigger("Jump");
        }
    }

    void SetAnim()
    {
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
        else
        {
            _anim.SetBool("IsMove", false);
        }


        _anim.SetBool("IsGrounded", isGrounded);

        if (_rigid.velocity.y <= -3f && isGrounded == false)
            _anim.Play("Falling");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리
        // 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면

            for (int i = 0; i < collision.contactCount; i++)
            {
            if (collision.contacts[i].normal.y > 0.9f)
                if (isGrounded == false)
                    _anim.Play("Idle");
                isGrounded = true;
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }
}
