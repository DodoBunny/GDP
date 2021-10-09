using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning_windmil : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0,speed));
    }
}
