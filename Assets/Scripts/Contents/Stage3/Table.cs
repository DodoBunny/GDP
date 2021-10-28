using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject OrderCanvas;

    public Sprite empty;
    public Sprite wait;
    public Sprite eat;

    SpriteRenderer sprite;
    Order order;


    public enum State
    {
        Empty,
        Wait,
        Eat
    }
    State state = State.Empty;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        order = OrderCanvas.GetComponent<Order>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Empty:
                sprite.sprite = empty;
                if (!onEmpty)
                {
                    Invoke("Empty", Random.Range(0f, 5f));
                    onEmpty = true;
                }
                break;
            case State.Wait:
                sprite.sprite = wait;
                if (!onWait)
                {
                    Wait();
                    onWait = true;
                }
                break;
            case State.Eat:
                sprite.sprite = eat;
                break;
        }
    }

    bool onEmpty = false;
    void Empty()
    {
        state = State.Wait;
    }

    bool onWait = false;
    void Wait()
    {
        for (int i = 0; i < Random.Range(4, 8); i++)
        {
            int randint = Random.Range(0, 3);
            switch (randint)
            {
                case 0:
                    order.Add(Define.Food.Beer);
                    break;
                case 1:
                    order.Add(Define.Food.Chicken);
                    break;
                case 2:
                    order.Add(Define.Food.Soju);
                    break;
            }
        }
    }
}
