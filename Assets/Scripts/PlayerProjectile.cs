using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D spark;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1")) 
       {
           spark = Instantiate(spark, transform.position, transform.rotation);
       }
    }
}
