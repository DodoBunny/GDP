using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator _anim;
    SpriteRenderer _sprite;
    RaycastHit2D hit;
    public GameObject Bullet;

    public float sight = 8f;
    public float speed = 3f;

    public bool randomAttack = false;
    public bool isFollow = false;

    bool targetLock = false;
    Vector3 patrolDir;
    enum State
    {
        Patrol,
        Follow,
        Attack,
        Die
    }
    State state = State.Patrol;

    private void Awake()
    {
        Managers.Game.NPCs++;
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("RandomPos", 0, Random.Range(1f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        DelayTime += Time.deltaTime;

        Ray();

        if (state != State.Die)
        {
            if (Mathf.Abs((Managers.Game.player.transform.position - transform.position).magnitude) < sight)
            {
                if (hit.collider == null)
                {
                    state = isFollow ? State.Follow : State.Patrol;
                }
                else
                    state = State.Attack;
            }
            else
            {
                state = State.Patrol;
            }

            if (GetComponent<Stat>().Hp <= 0)
            {
                state = State.Die;
                Managers.Game.NPCcount++;
                Managers.Game.NPCs--;
                GetComponent<AudioSource>().Play();
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

                if (DelayTime > Random.Range(1f, 2f) && randomAttack)
                {
                    Attack();
                }
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
                Attack();
                break;
            case State.Die:
                _anim.SetTrigger("Die");
                GetComponent<CapsuleCollider2D>().enabled = false;
                break;
        }
    }

    void Ray()
    {
        Vector3 Dir = _sprite.flipX ? Vector3.left : Vector3.right;

        Debug.DrawRay(transform.position, Dir * sight);
        hit = Physics2D.Raycast(transform.position, Dir, sight, LayerMask.GetMask("Player"));
    }

    void RandomPos()
    {
        Vector3 dir = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0).normalized;
        patrolDir = dir;
    }

    float DelayTime;
    public float AttackSpeed = 0.3f;
    void Attack()
    {
        if (Managers.Game.player.GetComponent<PlayerControllor2>().isDead)
            return;
        if (DelayTime > AttackSpeed)
        {
            float x = _sprite.flipX ? -0.5f : 0.5f;
            GameObject bullet = Instantiate(Bullet, transform.position + new Vector3(x, 0, 0), Quaternion.identity);
            bullet.GetComponent<WaterBullet>().flip = _sprite.flipX;
            bullet.GetComponent<WaterBullet>().isEnemy = true;
            DelayTime = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        patrolDir = -patrolDir;
    }
}
