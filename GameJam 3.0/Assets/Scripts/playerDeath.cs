using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
    public GameObject particles;

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
        GameObject go = Instantiate(particles, transform.position, transform.rotation);
        go.GetComponent<objectiveBehavior>().objective = (objectivesDisplay.Objectives)GetComponent<colorGroup>().color - 1;
        Destroy(gameObject);
    }
}
