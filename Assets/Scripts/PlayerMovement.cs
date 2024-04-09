using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collision2D groundCol;
    private SpriteRenderer playerSprite;
    private float timer = 0f ;
    public bool grounded;
    public bool canJump;
    private int jumps = 2;
    // Start is called before the first frame update
    private void Start()
    {
        Damage.damageEvent += die;
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>(); 
    }

    private void die()
    {
        Debug.Log("Death function goes here.");
    }

    void OnCollisionEnter2D(Collision2D groundCol)
    {
        grounded = true;
        canJump = true;
        jumps = 2;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Made timer to allow wall jumping
        timer = .05f;
        grounded = false;
        //Jump set to 1 allows for only one "air" jump
        jumps = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0 && grounded == false && jumps == 0)
        {
            canJump = false;
        }
        float dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        if (dirX > 0)
        {
            playerSprite.flipX = false;
        }
        else if (dirX < 0)
        {
            playerSprite.flipX = true;
        }
        if (Input.GetButtonDown("Jump") && canJump)
        {
            jumps--;
            rb.velocity = new Vector2(0, 10f);
        }

    }
}
