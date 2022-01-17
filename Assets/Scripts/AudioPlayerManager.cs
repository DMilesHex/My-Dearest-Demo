using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    private static AudioPlayerManager instance = null;
    private AudioSource audioSrc;
    private int audioID;
    public AudioClip[] song;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioID = Random.Range(0, 2);
        print(audioID);
        audioSrc.clip = song[audioID];
        
        audioSrc.Play();
    }
}
