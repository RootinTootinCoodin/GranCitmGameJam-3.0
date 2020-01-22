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
        audioSource.clip = clip;
        audioSource.Play();
    }
}
