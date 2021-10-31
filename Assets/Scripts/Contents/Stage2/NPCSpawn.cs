using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public GameObject NPC4;
    public GameObject NPC5;

    public float SpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        if (Managers.Game.NPCs >= 20)
            return;

        int rand = Random.Range(1, 6);

        switch (rand)
        {
            case 1:
                Instantiate(NPC1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(NPC2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(NPC3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(NPC4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(NPC5, transform.position, Quaternion.identity);
                break;
        }
    }
}
