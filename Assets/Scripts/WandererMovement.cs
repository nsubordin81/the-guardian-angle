using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    (float, float) facingDirection;

    (float, float) up = (0,1);
    (float, float) down = (0,-1);
    (float, float) left = (-1,0);
    (float, float) right = (1,0);

    public Rigidbody2D rb;
    Vector2 movement;
    
    bool facingRight = true;
    // wanderer searches until it finds its purpose
    bool searching = true;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        facingDirection = right;
        //this was to get them unstuck but now the player is responsible for that
        // StartCoroutine(moveRandomly());
    }

    (float, float) updateOrientation((float, float) currentDirection) {
        if(currentDirection == up){return right;}
        if(currentDirection == right){return down;}
        if(currentDirection == down){return left;}
        if(currentDirection == left){return up;}
        return right;
        
    }

    IEnumerator moveRandomly()
    {
        float idleTime = 20;
        while(searching){
            yield return new WaitForSeconds(idleTime);
            facingDirection = stochasticUpdateOrientation();
        }
    }

    private (float, float) stochasticUpdateOrientation() {
        var values = new[] { up, down, left, right };
        return values[Random.Range(0,3)];
    }

    void Update()
    {
        movement.x = facingDirection.Item1;
        movement.y = facingDirection.Item2;

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
        // follow the current movement vector
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        // if you hit a wall, turn to the next cardinal direction
        if(collision.gameObject.tag == "Wall") 
        {
            // this actually made the game harder than manually turning player
            // StartCoroutine(collisionTurn(collision));
        } else if(collision.gameObject.tag == "Spark") 
        {
            // it's hard enough without predicting where the wanderer is going to go next
            // StartCoroutine(moveRandomly());
            facingDirection = updateOrientation(facingDirection);
            Destroy(collision.gameObject);
        }
    }



    IEnumerator collisionTurn(Collision2D collision) 
    {
        // bump this game object back a bit so that it can register future collisions with the same composite collider
        float force = 1000;
        Vector2 dir = collision.contacts[0].point - (Vector2) transform.position;
        dir = -dir.normalized;
        GetComponent<Rigidbody2D>().AddForce(dir*force);
        
        yield return new WaitForSeconds(.5f);
        facingDirection = updateOrientation(facingDirection);
    }

    void OnTriggerEnter2D(Collider2D trigger) {
    }

}
