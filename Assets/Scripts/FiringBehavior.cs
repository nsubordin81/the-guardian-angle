using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehavior : MonoBehaviour
{   
    public Rigidbody2D rb;
    public float moveSpeed = 10;
    public Vector2 movement;
    public bool finishedMoving = false;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       StartCoroutine(waitToStop());
    }

    IEnumerator waitToStop() {
        yield return new WaitForSeconds(1);
        finishedMoving = true;
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update() {}

    void FixedUpdate()
    {
        if(!finishedMoving)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

}
