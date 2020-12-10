using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed = 10f;
    public float rocketForce = 2f;
    public float jumpForce = 1000f;

    public float fuelLevel = 0f; // TODO max fuel level

    public string message = "";

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine("LevelStart");

    }

    IEnumerable LevelStart() // Currently not working
    {
        Debug.Log("LevelStart coroutine started.");
        message = "Let's play: Capture the Flag!";
        yield return new WaitForSecondsRealtime(5.5f);
        message = "";
        Debug.Log("LevelStart coroutine ended.");
    }

    // Update is called once per frame
    void Update()
    {
        ForceMove();
        Jump();
        Rocket();
    }

    void OnGUI()
    {
        
        GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 100), message);

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

            if (Mathf.Abs(inputAxisValue) > 0.1)
            {
                Vector3 movement = new Vector3(0f, 0.2f, 0f);
                body.AddForce(movement * rocketForce);
                fuelLevel = Mathf.Max(fuelLevel - 0.001f, 0); // want to change to factor in the framerate
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Consumable"))
        {
            Destroy(other.gameObject);
            fuelLevel = Mathf.Min(fuelLevel + 0.2f, 1);
        }

        if (other.gameObject.CompareTag("Finish"))
        {

            Debug.Log("Collision with end trigger.");
            StartCoroutine("EndLevel");
        }
    }

    // end level behavior
    IEnumerator EndLevel()
    {
        // Text: you won!
        message = "You won!";


        // Also stop the motion at flag.

        

        yield return new WaitForSecondsRealtime(4.5f);
        
        // Reloads scene.  Eventually it would look for the next scene and load that instead.
        SceneManager.LoadScene("SampleScene");
    }



}
