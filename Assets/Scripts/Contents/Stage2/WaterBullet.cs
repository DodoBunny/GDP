using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public float speed = 2f;
    public bool flip = false;
    public bool isEnemy = false;

    Vector3 randDir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        randDir = new Vector3(0, Random.Range(-0.1f, 0.1f));
    }

    private void Update()
    {
        if (flip)
            transform.position += (Vector3.left + randDir).normalized * Time.deltaTime * speed;
        else
            transform.position += (Vector3.right + randDir).normalized * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (isEnemy)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Stat>().OnDamaged();
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "NPC")
            {
                collision.gameObject.GetComponent<Stat>().OnDamaged();
                Destroy(gameObject);
            }
        }
    }
}
