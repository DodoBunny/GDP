using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject character;
    Stat stat;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        stat = character.GetComponent<Stat>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = stat.Hp / (float)stat.maxHp;
    }
}
