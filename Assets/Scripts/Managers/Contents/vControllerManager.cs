using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vControllerManager : MonoBehaviour
{
    GameObject vController;

    // Start is called before the first frame update
    void Start()
    {
        vController = GameObject.Find("VirtualController");

#if UNITY_EDITOR
        Debug.Log("에디터 실행");
        vController.SetActive(false);
#endif

    }

}
