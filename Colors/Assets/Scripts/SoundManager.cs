using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip attack, doublejump, damage, caves;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        attack = Resources.Load<AudioClip>("attack");
        doublejump = Resources.Load<AudioClip>("doublejump");
        damage = Resources.Load<AudioClip>("damage");
        caves = Resources.Load<AudioClip>("caves");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "damage":
                audioSrc.PlayOneShot(damage);
                break;
            case "doublejump":
                audioSrc.PlayOneShot(doublejump);
                break;
            case "atak":
                audioSrc.PlayOneShot(attack);
                break;
            case "caves":
                audioSrc.PlayOneShot(caves);
                break;
        }
    }
}
