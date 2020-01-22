using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


enum State
{
    IDLE,
    WALKING,
    JUMPING
}

public class playerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 5.0f;

    PlayerActions actions;

    State currentState;
    State newState;

    Animator animator;
    SpriteRenderer sprite;

    AudioSource playerSound;
    public AudioClip jump;

    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerSound = GetComponent<AudioSource>();



        actions = new PlayerActions();

        actions.Gameplay.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        actions.Gameplay.Movement.canceled += ctx => Stop();

        actions.Gameplay.Jump.performed += ctx => Jump();

        currentState = State.IDLE;
        newState = State.IDLE;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * movement.x * speed * Time.deltaTime);

        if(currentState != newState){
            switch (newState)
            {
                case State.JUMPING:
                    animator.SetTrigger("Jump");
                    playerSound.clip = jump;
                    playerSound.Play();
                break;
                case State.WALKING:
                    animator.SetTrigger("Walk");
                break;
                case State.IDLE:
                    animator.SetTrigger("Idle");
                break;

            }

            currentState = newState;
        }

    }

    void Jump()
    {
        if (currentState != State.JUMPING)
        {
            rb.AddForce(Vector2.up * jumpForce);
            newState = State.JUMPING;
        }
    }

    void Move(Vector2 ctx_movement )
    {
        if (currentState == State.IDLE) newState = State.WALKING;
        movement = ctx_movement;
        sprite.flipX = movement.x > 0;
    
    }

    void Stop()
    {
        if (currentState == State.WALKING) newState = State.IDLE;
        movement = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
        {
            if (other.GetContact(0).normal == Vector2.up)
            {

                if (currentState == State.JUMPING)
                {
                    if (movement.x == 0)
                        newState = State.IDLE;
                    else
                        newState = State.WALKING;
                }
            }  
            else if (other.GetContact(0).normal == -Vector2.up && currentState != State.JUMPING)
            {
                GetComponent<playerDeath>().Die();
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
