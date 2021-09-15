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

    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float jumpPower = 20f;

    [SerializeField]
    bool isGrounded = false;


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
        GroundedCheck();
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
        else if (_rigid.velocity.x < -maxSpeed)
            _rigid.velocity = new Vector2(-maxSpeed, _rigid.velocity.y);

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

    void GroundedCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.blue, 0.5f);
        if (hit.transform != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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
        else if (_rigid.velocity.y <= 0 && _rigid.velocity.y >= -3 && isGrounded == false) // 떨어지고 있을 때 체크
        {
            _anim.SetBool("startFalling", true);
            _anim.SetBool("isFalling", true);
        }
        else if (_rigid.velocity.y <= -3 && isGrounded == false) // 떨어지고 있을 때 체크
        {
            _anim.SetBool("startFalling", false);
            _anim.SetBool("isFalling", true);
        }
        else
        {
            _anim.SetBool("IsMove", false);
            _anim.SetBool("isFalling", false);
        }

        _anim.SetBool("IsGrounded", isGrounded);
    }
}
