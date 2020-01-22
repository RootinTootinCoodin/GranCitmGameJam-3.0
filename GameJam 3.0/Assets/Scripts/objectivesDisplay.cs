using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectivesDisplay : MonoBehaviour
{
    public float barHeight = 200.0f;
    public float margins = 2.0f;

    public GameObject step;
    public bool isPreview = false;

    public enum Objectives
    {
        GREEN,
        YELLOW,
        RED
    };
    public Objectives[] objectives;

    public colorTemplate green;
    public colorTemplate yellow;
    public colorTemplate red;

    float stepheight = 0.0f;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        int num = objectives.Length;
        stepheight = (barHeight - (num - 1) * margins) / num;

        if (isPreview)
        {
            for(int i = 0; i < num; i++)
            {
                addStep(objectives[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPreview && count >= objectives.Length)
        {
            Debug.Log(objectives.Length);
            Win();
        }
    }

    public void addStep(Objectives color)
    {
        if (color != objectives[count])
        {
            Lose();
        }

        GameObject go = Instantiate(step, transform);

        go.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, ((stepheight + margins) * count + stepheight / 2));
        go.GetComponent<RectTransform>().sizeDelta = new Vector2(25.0f, stepheight);

        switch(color)
        {
            case Objectives.YELLOW:
                go.GetComponent<Image>().color = yellow.value;
                break;
            case Objectives.GREEN:
                go.GetComponent<Image>().color = green.value;
                break;
            case Objectives.RED:
                go.GetComponent<Image>().color = red.value;
                break;
        }
        

        count++;
    }

    public void Win()
    {
        Debug.Log("Win");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().Win();
    }

    public void Lose()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().Lose();
    }

    public Vector3 getNextPosition()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y+((stepheight + margins) * count + stepheight / 2)/1);
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(pos);
        cameraPos.z = 0.0f;
        return cameraPos;
    }
}
