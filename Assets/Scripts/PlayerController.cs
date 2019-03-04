using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public float speed = 10.0f;
    public float jumpForce = 500.0f;

    // Private Variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private GameController gameControllerScript;

    // Reserved function. Runs only once when object is created.
    // Used for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); // get gamecontroller object using tag

        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>(); // get gameControllerScript component
        }

        if(gameControllerScript == null) // if not found, show error at console
        {
            Debug.Log("Cannot find GameController script on GameController object");
        }
    }

    void Update()
    {
        // Raycast from your feet downwards towards the ground
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        // Listens to my space bar key being pressed
        if( Input.GetKeyDown(KeyCode.Space) && isGrounded ) 
        {
            anim.SetBool("Jump", isGrounded);
            rBody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            anim.SetBool("Jump", isGrounded);
        }
        
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        // Check direction of the player
        if( (horiz < 0) && isFacingRight )
        {
            Flip();
        }
        else if( (horiz > 0) && !isFacingRight )
        {
            Flip();
        }

        // Update Animator Information
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if( other.gameObject.CompareTag("Ground") )
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("colliding with enter: " + other.gameObject.name);

        if( other.gameObject.name == "StartTree" )
        {
            gameControllerScript.ShowStartText();
        }
        
        
        if( other.gameObject.name == "FinishSign" )
        {
            gameControllerScript.ShowFinishText();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("colliding with exit: " + other.gameObject.name);
        
        if( other.gameObject.name == "StartTree" )
        {
            gameControllerScript.HideStartText();
        }

        if( other.gameObject.name == "FinishSign" )
        {
            gameControllerScript.HideFinishText();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Negating current isFacingRight value
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
