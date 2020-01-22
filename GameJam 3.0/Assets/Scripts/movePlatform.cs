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

    List<GameObject> carrying;

    Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        carrying = new List<GameObject>();

        Vector2 direction = (axis == movingAxis.HORITZONTAL) ? Vector2.right : Vector2.up;

        transform.LeanMove(new Vector2(transform.position.x, transform.position.y) + direction * distance, Mathf.Abs(distance/speed)).setLoopPingPong();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (axis == movingAxis.HORITZONTAL)
        {
            Vector3 delta = transform.position - prevPos;
            
            foreach(GameObject go in carrying)
            {
                go.transform.Translate(delta);
            }
            prevPos = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (axis == movingAxis.HORITZONTAL && other.collider.tag == "Player")
        {
            carrying.Add(other.collider.gameObject);         
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (axis == movingAxis.HORITZONTAL && other.collider.tag == "Player")
        {
            carrying.Remove(other.collider.gameObject);
        }
    }
}
