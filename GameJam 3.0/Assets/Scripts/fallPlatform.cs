using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{
    public float fallTime;
    public float fallSpeed;

    bool countdown = false;
    bool falling = false;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling && countdown && Time.time - time >= fallTime)
        {
            transform.LeanMoveY(transform.position.y - 2000, 2000 / fallSpeed);
            falling = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Coolide");
        if (!countdown && other.collider.tag == "Player")
        {
            countdown = true;
            time = Time.time;
        }
        if (falling && other.collider.tag == "Obstacle")
        {
            Debug.Log("Wall");
            Destroy(gameObject);
        }
    }
}