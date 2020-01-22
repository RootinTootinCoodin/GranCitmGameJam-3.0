using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartGame()
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.volume = 0.04f;
        audioSource.Play();
    }
}
