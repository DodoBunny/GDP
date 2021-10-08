using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    Animator _anim;
    SpriteRenderer _sprite;

    public F_DialogueManager F_manager;
    //public LobbyScene
    public float maxdist = 10f;
    public float movedist = 2f;
    public float moveTime = 2f;
    public bool iscoll;

    string[] lines = new string[100];

    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 글자 크기 25로 하면 한줄에 45자 입력 가능 -> 총 90자 언저리

        lines[0] = "안녕 XX과에 입학한 OO맞지?. 나는 같은과 선배라고 해. 입시때 제외하곤" + "\n" + "학교 온게 처음일텐데 내가 학교 건물이랑 위치등을 알려줄게. 그럼 따라와!";
        // "안녕 난 가천대 과선배 XX야. 입시때 제외하곤 학교 온게 처음이지? 내가 학교 건물이랑 위치등을 알려줄게 그럼 따라와!"
        lines[1] = "여긴 프리덤광장이라고, 편의점, 서점, 식당, 카페 등등 학생들이 이용할 수 있는" + "\n" + "편의시설들이 모여있고, 우리가 왔던 지하철역과도 연결된 곳이야!";
        lines[2] = "여긴 스타덤광장이야. 학식당과 비전타워로 이어지는 통로도 있어. 옆 계단으로 가면 학생 서비스센터도 있으니 나중에 필요하면 가봐!";
        lines[3] = "이곳은 가천관이라고 부르는 곳으로, 지하에는 식당이, 1층에는 공부나 휴식을 위한 라운지가 있어. 밤에는 건물을 배경으로 트레이드마크인 바람개비를 불빛으로 눈에 띄게 만들어.저녁에 한번 와보는것도 좋아!";
        lines[4] = "여긴 바람개비동산이야. 야외에서 사람들이랑 모일때도 좋고, 특히 봄에는 이곳에서 행사를 많이하는데, 재밌으니 행사할때 놀러와봐!";
        lines[5] = "이건물은 글로벌센터야. 교양필수과목인 영어 과목을 들으러 오는곳이지. 앞으로 자주 올테니 기억해둬! 그리고 옆건물은 IT대야. 이 앞 무당이 정류장이 있어. 무당이를 타고가면 기숙사까지 한번에 갈수 있어서 기숙사생들이 자주 이용해.";


    }

    // Update is called once per frame
    void Update()
    {
        if ((Managers.Game.player.transform.position - transform.position).sqrMagnitude > maxdist)
        {
            transform.position = Managers.Game.player.transform.position;
        }


        if ((Managers.Game.player.transform.position - transform.position).sqrMagnitude > movedist)
        {
            _anim.SetBool("IsMove", true);
            float moveX = Mathf.Lerp(transform.position.x, Managers.Game.player.transform.position.x, moveTime * Time.deltaTime);
            transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        }
        else
        {
            _anim.SetBool("IsMove", false);
        }



        if (transform.position.x > Managers.Game.player.transform.position.x)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }


        if (Input.GetButtonDown("Interaction"))
        {
            F_manager.DialoguePanel.SetActive(false);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        iscoll = true;

        //if (collision.gameObject.tag == "F_Dialogue 1")
        //{
        //    F_manager.Action(lines[0]);
        //}
        //else if (collision.gameObject.tag == "F_Dialogue 2")
        //{
        //    F_manager.Action(lines[1]);
        //}

        for (int i = 0; i < lines.Length + 1; i++)
        {
            if (collision.gameObject.tag == "F_Dialogue " + (i + 1).ToString())
            {
                F_manager.Action(lines[i]);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        iscoll = false;

    }
}
