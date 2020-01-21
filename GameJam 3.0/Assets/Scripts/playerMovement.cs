using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 5.0f;

    PlayerActions actions;

    Vector2 movement;
    Rigidbody2D rb;
    bool onAir = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        actions = new PlayerActions();

        actions.Gameplay.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        actions.Gameplay.Movement.canceled += ctx => movement = Vector2.zero;

        actions.Gameplay.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * movement.x * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (!onAir)
        {
            rb.AddForce(Vector2.up * jumpForce);
            onAir = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
        {
            if (other.GetContact(0).normal == Vector2.up)
            {
                onAir = false;
            }         
        }
    }

    void OnEnable()
    {
        actions.Gameplay.Enable();
    }

    void OnDisable()
    {
        actions.Gameplay.Disable();
    }
}
