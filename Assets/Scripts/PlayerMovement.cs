using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d; //private variable
    Vector2 moveInput;// for walk with addforce
    //walk left-right
    private float move; // store input from player
    [SerializeField] private float speed;
    //jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isjumping;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);
        /*//walk left-right
       move = Input.GetAxis("Horizontal");
       rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);*/
       //jump
       if (Input.GetButtonDown("Jump") && !isjumping)
       {
           rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
           Debug.Log("Jump!"); // for debugging
       }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = true;
        }
    }
}
