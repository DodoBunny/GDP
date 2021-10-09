using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장된다
    static Managers Instance { get { Init(); return s_instance; } } // 유일한 매니저를 갖고온다

	#region Contents
	GameManager _game = new GameManager();
    DialogManager _dialog = new DialogManager();

    public static GameManager Game {  get { return Instance._game; } }
    public static DialogManager Dialog { get { return Instance._dialog; } }
    #endregion

    #region Core
    InputManager _input = new InputManager();
    SoundManager _sound = new SoundManager();

    public static InputManager Input { get { return Instance._input; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    #endregion

    void Start()
    {
        Init();
        _game.Init();
        _sound.Init();
	}

    void Update()
    {
        _input.OnUpdate();
        _game.OnUpdate();
        _dialog.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
			GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
	}

    public static void Clear()
    {
    }
}
