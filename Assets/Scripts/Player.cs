using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;



    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private bool canJump = true;
    private Rigidbody2D rb;


    public bool canGrab;

    public int extraJumpsValue = 1;
    private int extraJumps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        extraJumps = extraJumpsValue;

    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
            }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (health <= 0)
            {
                Die();
            }

        }
    }
  
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    }

