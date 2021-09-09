using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    /*
        TODO : 여러곳에서 반복적으로 사용될 수 있는 메소드 집합 
    */

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        //게임오브젝트의 컴포넌트를 가져온다, 해당 컴포넌트가 없을 시 접근한 게임오브젝트에 컴포넌트를 Add 후 가져온다. 
        T component = go.GetComponent<T>();
		if (component == null)
            component = go.AddComponent<T>();
        return component;
	}

}
