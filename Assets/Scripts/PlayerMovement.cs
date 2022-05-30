using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Animator animator;

    public Rigidbody2D rb;
    bool facingRight = true;

    Vector2 movement;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if(movement.x > 0 && !facingRight) 
        {
            flip();
        }
        if(movement.x < 0 && facingRight) 
        {
            flip();
        }
    }

    void flip() {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // Debug.Log("PlayerCollided!!!");
    }

    void OnTriggerEnter2D(Collider2D trigger) {
    }
}
