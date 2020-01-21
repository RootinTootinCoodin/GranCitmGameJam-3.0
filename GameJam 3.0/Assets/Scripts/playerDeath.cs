using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("Objectives").GetComponent<objectivesDisplay>().addStep((objectivesDisplay.Objectives)GetComponent<colorGroup>().color - 1);
        Destroy(gameObject);
    }
}
