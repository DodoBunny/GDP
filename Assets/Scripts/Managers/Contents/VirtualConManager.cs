using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualConManager : MonoBehaviour
{
    GameObject virtualController;

    // Start is called before the first frame update
    void Start()
    {
        virtualController = GameObject.Find("VirtualController");

#if UNITY_EDITOR
        Debug.Log("유니티 에디터에서 실행");
        virtualController.SetActive(false);
#endif

#if UNITY_ANDROID
        Debug.Log("안드로이드에서 실행");
        virtualController.SetActive(true);

#endif

#if UNITY_EDITOR_WIN
        Debug.Log("윈도우에서 실행");
        virtualController.SetActive(false);
#endif


    }

}

