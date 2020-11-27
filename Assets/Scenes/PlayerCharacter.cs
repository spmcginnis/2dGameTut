using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed = 10f;
    public float rocketForce = 20f;
    public float jumpForce = 1000f;

    public float fuelLevel = 0f; // TODO max fuel level

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForceMove();
        Jump();
        Rocket();
    }



//    FixedUpdate

    void ForceMove()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * speed;

        body.AddForce(movement * speed);
    }

    void Jump()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        Vector3 movement = new Vector3(0f, jumpForce, 0f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down*1.2f, Vector2.down, .1f);


        if (Input.GetKeyDown("space") && hit.collider != null && hit.distance < 1)
        {

    

            print("Object at distance: " + hit.distance);
            print("Contact at point: " + hit.point);        
            body.AddForce(Vector2.up * jumpForce);


           
        }

        Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.red);
    }


    void Rocket()
    {
        if (fuelLevel > 0)
        {
            Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();

            float inputAxisValue = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(0f, inputAxisValue, 0f);

            body.AddForce(movement * rocketForce);

            if (inputAxisValue != 0)
            {
                Debug.Log("Input axis value: " + inputAxisValue);
                fuelLevel = Mathf.Max(fuelLevel - Mathf.Abs(inputAxisValue) / 360, 0); // want to change to factor in the framerate
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with trigger.");
        if (other.gameObject.CompareTag("Consumable"))
        {
            Destroy(other.gameObject);
            fuelLevel = Mathf.Min(fuelLevel + 0.2f, 1);
        }
    }


}
