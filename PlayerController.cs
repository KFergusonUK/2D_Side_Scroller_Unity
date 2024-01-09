using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight;

    // Reference to the JumpScript
    private JumpScript jumpScript;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3f;

        // Find and store the JumpScript component
        jumpScript = GetComponentInChildren<JumpScript>(); // Assuming JumpScript is a child of PlayerControl
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        // Call the JumpScript's Update method
        jumpScript.UpdateJump();

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            jumpScript.StartJump();
        }
    }

    void FixedUpdate()
    {
        // Method of movement, more suitable for 2d Beat 'em up, with y-axis movement:
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed, moveVertical * moveSpeed, 0.0f);
        transform.position += movement * Time.deltaTime;

        // Flip player's sprite when going left or right:
        flip(moveHorizontal);
    }

    // Flip player sprite horizontally depending on facing direction:
    void flip(float moveHorizontal)
    {
        if (moveHorizontal < 0 && !facingRight || moveHorizontal > 0.1 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
