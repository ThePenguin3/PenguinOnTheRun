using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator animator;
    private float moverHorizontal = 5f;
    

    [Header("X movements")]
    [SerializeField] private float velocidad;







    void Start() // Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //Application.targetFrameRate = 60;
        

    }


    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }


    void Update() // Update is called once per frame
    {
        AxisMove();
        FlipAxis();

        /*
        if (!IsGrounded() && rb.velocity.y > 0.2) //in the air
        {
             animator.SetBool("isJumping", true);
            

        }

        if (IsGrounded()) //si toca el suelo recarga salto
        {
            dobleSalto = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDobleJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.W) == true) //W = salto
        {   
            VerticalMove();
        }
        */
        animator.SetFloat("Speed", Mathf.Abs(moverHorizontal));
        //1 o -1, es necesario multiplicarlo para que alcance una velocidad más notoria        
        //vector2 es el tipo de vector(R2)/velocidadResultante es el nombre del vector creado

    }


    void AxisMove()
    {
        moverHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 velocidadResultante = new Vector2(moverHorizontal * velocidad, rb.velocity.y);
        rb.velocity = velocidadResultante;

    }

    /*
    void VerticalMove()
    {
        if (IsGrounded())
        {
            canJump = true; //se verifica que esta en el suelo, podria saltar
            dobleSalto = true;

        }
    

        if (canJump) //if you were in ground
        {
            rb.velocity = jumpForce * Time.fixedDeltaTime * Vector2.up;//aplicacion de la fuerza externa (ejecutar salto)
 
            canJump = false;
        }

        else if (!canJump && dobleSalto)  //not in ground but still have double jump
        {   

            rb.velocity = secondJump * Time.fixedDeltaTime * Vector2.up; //second jump
            dobleSalto = false; //until next ground
            animator.SetBool("isDobleJumping", true);
        }
    }
    */


    void FlipAxis()
    {
        if (rb.velocity.x < -0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (rb.velocity.x > 0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }


}
