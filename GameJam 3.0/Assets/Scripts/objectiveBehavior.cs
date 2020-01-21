using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveBehavior : MonoBehaviour
{
    [HideInInspector]
    public objectivesDisplay.Objectives objective;

    public colorTemplate green;
    public colorTemplate yellow;
    public colorTemplate red;

    // Start is called before the first frame update
    void Start()
    {      
        switch (objective)
        {
            case objectivesDisplay.Objectives.YELLOW:
                GetComponent<ParticleSystem>().startColor = yellow.value;
                break;
            case objectivesDisplay.Objectives.GREEN:
                GetComponent<ParticleSystem>().startColor = green.value;
                break;
            case objectivesDisplay.Objectives.RED:
                GetComponent<ParticleSystem>().startColor = red.value;
                break;
        }

        Vector3 objectivePos = GameObject.FindGameObjectWithTag("Objectives").GetComponent<objectivesDisplay>().getNextPosition();
        LTBezierPath ltPath = new LTBezierPath(new Vector3[] { transform.position, transform.position+new Vector3(0f, 2f, 0f), objectivePos + new Vector3(-2f, 0f, 0f), objectivePos });

        LeanTween.move(gameObject, ltPath, 0.75f).setOrientToPath(false).setDelay(0.25f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(Completed); // animate 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Completed()
    {
        GameObject.FindGameObjectWithTag("Objectives").GetComponent<objectivesDisplay>().addStep(objective);
        Destroy(gameObject);
    }
}
