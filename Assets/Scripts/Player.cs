using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;



    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private bool canJump = true;
    private Rigidbody2D rb;


    public bool canGrab;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }


    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
            

            Moveable M = other.GetComponent<Moveable>();
            if (Input.GetKeyDown(KeyCode.F) && canGrab)
            {
                Debug.Log("help");
                moveSpeed = 1.5f;
                canJump = false;
        }
            if (Input.GetKeyUp(KeyCode.F))
            {
                Debug.Log("let go");
                moveSpeed = 5.0f;
                canJump = true;
        }

        }
    }

