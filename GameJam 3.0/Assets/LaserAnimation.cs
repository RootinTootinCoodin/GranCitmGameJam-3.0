using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation : MonoBehaviour
{
    public float anim_speed = 0.5f;
    public float reduction_limit = 0.7f;
    bool leaning = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.LeanScaleY(reduction_limit, anim_speed);
    }

    // Update is called once per frame
    void Update()
    {
  
        if(!LeanTween.isTweening())
                if(transform.localScale.y < 1.0f)
                    transform.LeanScaleY(1.0f, anim_speed);
                else
                    transform.LeanScaleY(reduction_limit, anim_speed);









    }
}
