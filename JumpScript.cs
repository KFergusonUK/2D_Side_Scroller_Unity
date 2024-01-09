using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float jumpForce;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = 30f;
        isJumping = false;
    }

    // Update is called once per frame
    public void UpdateJump()
    {
        // Handle any jump-related input or checks here
    }

    public void StartJump()
    {
        if (!isJumping)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            Debug.Log("Jumping is now true");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            Debug.Log("Jumping is now false");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            Debug.Log("Jumping is now true");
        }
    }
}
