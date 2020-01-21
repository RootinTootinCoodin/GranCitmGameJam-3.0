using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(colorGroup))]
public class laser : MonoBehaviour
{
    colorGroup color;

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<colorGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<colorGroup>().color = color.color;
        col.gameObject.GetComponent<colorGroup>().UpdateColor();
    }
}
