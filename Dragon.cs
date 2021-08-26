using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // public properties
    public float velocityX = 15;
    public float jumpForce = 40;

    // private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    
    // private properties
    
    // constants
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_ATACTK= 2;
    private const int ANIMATION_JUMP= 3;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando Game Object");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_IDLE); 
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y); 
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }
        
        if (Input.GetKey(KeyCode.X))
        {
            changeAnimation(ANIMATION_ATACTK);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP); 
        }
    }
    private void changeAnimation(int animation)
    {
        //animator.SetInteger("Estado", animation);
    }
}
