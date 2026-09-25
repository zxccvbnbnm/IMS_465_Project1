using JetBrains.Annotations;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float moveSpeed = 0f;
    private Rigidbody2D rb;

    public bool held;
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
        if (held == true && Input.GetKeyDown(KeyCode.F))
        {
            moveSpeed = 1.5f;
            
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            moveSpeed = 0f;
        }
    }



    }

