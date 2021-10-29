using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CapsuleCollider2D _collider;
    Rigidbody2D _rigid;
    Animator _anim;
    SpriteRenderer _sprite;
    AudioSource _audio; // 점프 효과음

    public bool canMove = true;

    public float moveSpeed = 10f;
    public float jumpPower = 20f;
    public float maxSpeed = 20f;

    [SerializeField]
    private bool isGrounded = false;

    public float distance;
    public float angle;

    LayerMask groundMask;
    public Transform chkPos;
    public float checkRadius;

    // Mobile Key Var
    public int left_Value;
    public int right_Value;


    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        groundMask = LayerMask.GetMask("Ground");

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        SetAnim();
        GroundChk();

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        

        if (canMove)
        {
            _rigid.AddForce(Vector2.right * (Managers.Input.horizontal + right_Value + left_Value) * moveSpeed, ForceMode2D.Impulse);

            if (_rigid.velocity.x > maxSpeed)
                _rigid.velocity = new Vector2(maxSpeed, _rigid.velocity.y);
            else if (_rigid.velocity.x < maxSpeed * (-1))
                _rigid.velocity = new Vector2(maxSpeed * (-1), _rigid.velocity.y);
        }

    }

    void Jump()
    {
        if (!isGrounded || !canMove)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _audio.Play(); // 점프 효과음 재생
            _anim.SetTrigger("Jump");
        }

    }

    public void mJump()
    {
        if (!isGrounded || !canMove)
            return;

        _rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        _audio.Play(); // 점프 효과음 재생
        _anim.SetTrigger("Jump");
        

    }

    void SetAnim()
    {
        if (canMove)
        {
            if (Managers.Input.horizontal < 0 || left_Value == -1)
            {
                _anim.SetBool("IsMove", true);
                _sprite.flipX = true;
            }
            else if (Managers.Input.horizontal > 0 || right_Value == 1)
            {
                _anim.SetBool("IsMove", true);
                _sprite.flipX = false;
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

        _anim.SetBool("IsGrounded", isGrounded);

        if (_rigid.velocity.y <= -3f && isGrounded == false)
            _anim.Play("Falling");

    }

    void GroundChk()
    {
        isGrounded = Physics2D.OverlapCircle(chkPos.position, checkRadius, groundMask);

    }

    public void OnMouseDownAsButton(string type)
    {
        switch (type)
        {
            case "L":
                left_Value = -1;
                //left_Down = true;
                break;
            case "R":
                right_Value = 1;
                //right_Down = true;
                break;

        }

    }


    public void OnMouseUpAsButton(string type)
    {
        switch (type)
        {
            case "L":
                left_Value = 0;
                //left_Down = true;
                break;
            case "R":
                right_Value = 0;
                //right_Up = true;
                break;

        }
    }

}
