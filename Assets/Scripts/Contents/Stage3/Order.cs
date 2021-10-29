using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public GameObject OrderUI;
    public GameObject Beer, Chicken, Soju;
    public Define.Food[] inven = new Define.Food[8];
    public GameObject[] items = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inven.Length; i++)
        {
            inven[i] = Define.Food.Empty;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i] == Define.Food.Empty && items[i] != null)
            {
                Destroy(items[i]);
            }
        }

        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i] == Define.Food.Empty)
            {
                OrderUI.SetActive(false);
            }
            else
            {
                OrderUI.SetActive(true);
                break;
            }
        }
    }

    public void Add(Define.Food food)
    {
        if (food == Define.Food.Empty)
            DeleteAll();

        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i] != Define.Food.Empty)
            {
                continue;
            }
            else
            {
                switch (food)
                {
                    case Define.Food.Beer:
                        inven[i] = Define.Food.Beer;
                        items[i] = Instantiate(Beer, OrderUI.transform);
                        break;

                    case Define.Food.Chicken:
                        inven[i] = Define.Food.Chicken;
                        items[i] = Instantiate(Chicken, OrderUI.transform);
                        break;

                    case Define.Food.Soju:
                        inven[i] = Define.Food.Soju;
                        items[i] = Instantiate(Soju, OrderUI.transform);
                        break;
                }
                break;
            }
        }
    }

    public void Delete(Define.Food food)
    {
        for (int i = 0; i < inven.Length; i++)
        {
            if (inven[i] == food)
            {
                inven[i] = Define.Food.Empty;
                Destroy(items[i]);
                break;
            }
        }
    }

    public void DeleteAll()
    {
        for (int i = 0; i < inven.Length; i++)
        {
            inven[i] = Define.Food.Empty;
        }
    }

}
