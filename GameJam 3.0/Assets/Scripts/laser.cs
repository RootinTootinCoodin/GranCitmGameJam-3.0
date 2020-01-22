using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(colorGroup))]
public class laser : MonoBehaviour
{
    colorGroup color;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<colorGroup>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<colorGroup>().color = color.color;
        col.gameObject.GetComponent<colorGroup>().UpdateMaterial();
        if(audioSource) audioSource.Play();
    }
}
