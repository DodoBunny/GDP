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
        if (PlayerPrefs.HasKey("Score"))
        {
            text.text = "High Score : " + PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            text.text = "기록이 없습니다";
        }
    }
}
