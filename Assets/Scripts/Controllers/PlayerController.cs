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

    // Dialogue
    Vector3 dirVec; // 단위 벡터 (방향을 알기위함)
    float h;
    public DialogueManager D_manager;
    public GameObject scanObject; // 스캔 오브젝트

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
        Direction();
        Scan();
        Jump();
        SetAnim();
        GroundChk();

    }

    private void FixedUpdate()
    {
        Move();
        Ray();

    }

    void Move()
    {
        if (canMove)
        {
            _rigid.AddForce(Vector2.right * Managers.Input.horizontal * moveSpeed, ForceMode2D.Impulse);

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

    void Direction()
    {
        h = Input.GetAxisRaw("Horizontal");

        // Direction
        if (h == 1) // 오른쪽 방향키를 누르면 1이 입력
        {
            dirVec = Vector3.right; // dirVec에 오른쪽
        }
        else if (h == -1) // 왼쪽 방향키를 누르면 -1이 입력
        {
            dirVec = Vector3.left; // dirVec에 왼쪽
        }

    }

    void Ray()
    {
        Debug.DrawRay(_rigid.position, dirVec * 0.7f, Color.red); // Ray 그리기 1
        Debug.DrawRay(_rigid.position, (-1) * dirVec * 0.7f, Color.red); // Ray 그리기 2

        RaycastHit2D rayHit = Physics2D.Raycast(_rigid.position, dirVec, 0.7f, LayerMask.GetMask("Dialogue")); // Raycast 효과 넣기 1
        RaycastHit2D rayHit2 = Physics2D.Raycast(_rigid.position, (-1) * dirVec, 0.7f, LayerMask.GetMask("Dialogue")); // Raycast 효과 넣기 2

        if (rayHit.collider != null) // Ray에 닿는 콜라이더가 있다면
        {
            scanObject = rayHit.collider.gameObject; // scanObject에 그 콜라이더 오브젝트를 넣어준다.

        }
        else if (rayHit2.collider != null)
        {
            scanObject = rayHit2.collider.gameObject;

        }
        else
        {
            scanObject = null; // scanObject에 null을 넣어준다.
        }

    }

    void Scan() // v키(Interaction)을 누르면 함수 실행
    {
        if (Input.GetButtonDown("Interaction") && scanObject != null) // v키를 누르고 scanObject가 있다면
        {
            D_manager.Action(scanObject); // Action함수 실행
        }
        else if (Input.GetButtonDown("Interaction") && scanObject == null)
        {
            D_manager.DialoguePanel.SetActive(false);
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

    void GroundChk()
    {
        isGrounded = Physics2D.OverlapCircle(chkPos.position, checkRadius, groundMask);

    }
}
