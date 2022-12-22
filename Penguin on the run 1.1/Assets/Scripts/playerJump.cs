using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;

    public Animator animator;
    public float jumpForce = 16f;
    
    
    private bool isJumping = false;
    
    
    public float fastDown = -7f;

    private float contarTiempo = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //Application.targetFrameRate = 60;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S)) { 
            rb.velocity = Vector2.up* fastDown;
            if (!IsGrounded()) 
            {
                animator.SetBool("isJumping", true);
            }
        }
        
        if (IsGrounded())
            {
            contarTiempo += Time.deltaTime;
            if(contarTiempo > 0.1f) {
                animator.SetBool("isJumping", false);

            }
            animator.SetBool("bGround", true);
            
                if (Input.GetKeyDown(KeyCode.W)) //el suelo y el input habilita el salto, isjumping true
                {
                    animator.SetBool("isJumping", true);
                    contarTiempo = 0; //resetea el contador al saltar
                    isJumping = true;
                    
                    
                    rb.velocity = jumpForce * Vector2.up;
                }
        }
        

        if (isJumping)
        {
            if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > jumpForce/1.5f)
            {
                isJumping = false;
                rb.velocity = jumpForce * Vector2.up/1.5f;
                
            }
        }

    
    }


    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

}