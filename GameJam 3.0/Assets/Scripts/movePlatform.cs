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
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = (axis == movingAxis.HORITZONTAL) ? Vector2.right : Vector2.up;

        transform.LeanMove(new Vector2(transform.position.x, transform.position.y) + direction * distance, Mathf.Abs(distance/speed)).setLoopPingPong();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
