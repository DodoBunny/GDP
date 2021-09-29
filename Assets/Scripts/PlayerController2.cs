using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D rig;
    float inputX;
    public int moveSpeed;
    public LayerMask groundMask;

    public Transform chkPos;
    public bool isGround;
    public float checkRadius;

    public float jumpPower = 1;
    bool isJump;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        GroundChk();
        Flip();

        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Mathf.Abs(inputX));
    }

    public float maxangle;
    private void FixedUpdate()
    {
        rig.velocity = new Vector2(inputX * moveSpeed, rig.velocity.y);

        Jump();
    }

    void GroundChk()
    {
        isGround = Physics2D.OverlapCircle(chkPos.position, checkRadius, groundMask);
    }

    void Flip()
    {
        if (inputX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (inputX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Jump()
    {
        if (rig.velocity.y <= 0)
            isJump = false;

        if (isGround)
        {
            if (Input.GetAxis("Jump") != 0)
            {
                isJump = true;
                rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }
}
