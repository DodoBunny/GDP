using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    SpriteRenderer parentSprite;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Awake()
    {
        parentSprite = transform.parent.GetComponent<SpriteRenderer>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.sprite = parentSprite.sprite;
        sprite.flipX = parentSprite.flipX;
    }
}
