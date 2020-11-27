using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBlockBehavior : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        

        Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();

        Vector2 velocity = collision.relativeVelocity;

        // body.AddForce(Vector2.Reflect(velocity, Vector2.up) *100f);

        Vector2 bounce = Vector2.Reflect(velocity, Vector2.up) * 100f;
        body.AddForce(bounce);

        //Debug.Log("Rel Vel: " + velocity + "  Reflected Force: " + bounce );


        if (velocity.magnitude > 2)
        {
            audioSource.Play();
        }
        
    }


}

