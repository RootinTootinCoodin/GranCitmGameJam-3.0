using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{

    public enum movingAxis
    {
        HORITZONTAL,
        VERTICAL
    };
    public movingAxis axis;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (axis == movingAxis.HORITZONTAL)? Vector2.right : Vector2.up;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
