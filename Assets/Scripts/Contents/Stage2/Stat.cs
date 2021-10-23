using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int maxHp = 100;
    public int Hp = 100;

    // Start is called before the first frame update
    void Awake()
    {
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDamaged()
    {
        this.Hp--;
    }
}
