using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public AudioClip BGM_clip;
    public AudioClip Food_clip;
    public AudioClip Drink_clip;
    public AudioClip Book_clip;

    public AudioSource BGM;
    public AudioSource Item;


    public void Init()
    {
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        Item = GameObject.Find("Item").GetComponent<AudioSource>();

        BGM_clip = Resources.Load("Sounds/Music/BGM") as AudioClip;
        Food_clip = Resources.Load("Sounds/SFX/Food") as AudioClip;
        Drink_clip = Resources.Load("Sounds/SFX/Drink") as AudioClip;
        Book_clip = Resources.Load("Sounds/SFX/Book") as AudioClip;

        BGM.clip = BGM_clip;
        BGM.Play();
        BGM.loop = true;
}
    
    public void Play(Define.Sounds soundName)
    {
        switch (soundName)
        {
            case Define.Sounds.Book:
                Item.PlayOneShot(Book_clip);
                break;
            case Define.Sounds.Drink:
                Item.PlayOneShot(Drink_clip);
                break;
            case Define.Sounds.Food:
                Item.PlayOneShot(Food_clip);
                break;
        }
    } 
}
