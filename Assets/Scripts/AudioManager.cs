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

    // Start is called before the first frame update
    void Start()
    {
        player.soundEvent.AddListener(PlaySound);
    }

    // Update is called once per frame
    void Update()
    {
        
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
