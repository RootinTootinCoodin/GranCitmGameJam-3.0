using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        if (!finished)
        {
            winMenu.SetActive(true);
            finished = true;
        }
    }

    public void Lose()
    {
        if (!finished)
        {
            loseMenu.SetActive(true);
            finished = true;
        }
    }
}
