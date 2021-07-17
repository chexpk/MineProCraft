using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Player player;

    public AudioClip shoot;
    public AudioClip hit;

    void Start()
    {
        player.soundEvent.AddListener(PlaySound);
    }

    void PlaySound(string nameEvent)
    {
        if (nameEvent == "shoot")
        {
            audioSource.PlayOneShot(shoot);
        }
        if (nameEvent == "hit")
        {
            audioSource.PlayOneShot(hit);
        }
    }
}
