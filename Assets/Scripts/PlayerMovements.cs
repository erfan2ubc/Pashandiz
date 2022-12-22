using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private float moveSpeed;
    private float jumpForce;
    private float moveLeftRight;
    private float jump;
    private bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        
        moveSpeed = 1f;
        jumpForce = 20f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveLeftRight = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        if (moveLeftRight > 0.1f || moveLeftRight < -0.1f)
        {
            rb2d.AddForce(new Vector2(moveLeftRight * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping &&jump > 0.1f)
        {
            rb2d.AddForce(new Vector2(0, jump * jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
