using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collision2D groundCol;
    public bool grounded;
    // Start is called before the first frame update
    private void Start()
    {
        Damage.damageEvent += die;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D groundCol)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(0, 14f);
        }

    }

    void die(){
        Debug.Log("Death function goes here.");
    }

}
