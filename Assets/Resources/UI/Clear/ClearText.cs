using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearText : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Total Score : " + Managers.Game.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
