using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public GameObject particles;
    bool dead = false;

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
        if (!dead)
        {
            dead = true;
            GameObject go = Instantiate(particles, transform.position, transform.rotation);
            go.GetComponent<objectiveBehavior>().objective = (objectivesDisplay.Objectives)GetComponent<colorGroup>().color - 1;
            Destroy(gameObject);
        }
    }
}
