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
    public AudioClip fallSound;

    Vector2 movement;
    Rigidbody2D rb;
    Collider2D collider;
    public LayerMask mask;
    ContactPoint2D lastContact;

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

        actions.Gameplay.Reset.performed += ctx => ResetLevel();

        actions.Gameplay.Menu.performed += ctx => mainMenu();

        currentState = State.IDLE;
        newState = State.IDLE;
    }

    void Start()
    {
        Stop();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + 0.05f, mask);
        if (currentState == State.JUMPING && hit.collider != null && hit.collider.tag == "Obstacle")
        {
            newState = State.IDLE;

            playerSound.clip = fallSound;
            playerSound.Play();
        }
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
            playerSound.clip = jump;
            playerSound.Play();
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
        rb.velocity = Vector2.up * rb.velocity;
    }

    void ResetLevel()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().reloadScene();
    }

    void mainMenu()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>().loadIndexScene(0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
        {
            lastContact = other.GetContact(0);
            if (Vector2.Angle(-Vector3.up, lastContact.normal) <= 0.1f && currentState != State.JUMPING)
            {
                GetComponent<playerDeath>().Die();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
        {
            if (Vector2.Angle(Vector3.up, lastContact.normal) <= 0.1f && currentState != State.JUMPING)
            {
                newState = State.JUMPING;
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

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(collider.bounds.center, collider.bounds.center + Vector3.down * (collider.bounds.extents.y + 0.05f));
    }*/
}
