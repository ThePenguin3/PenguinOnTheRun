using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterController : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator animator;
    


    [Header("any movement")]
    [SerializeField] private float velocidad;

    public float yMax; //set borders
    public float yMin;

    public Transform xLeftLimit;
    public Transform xRightLimit;

    public float velocidadX;
    private float oldVelocidadX;

    public float tiempo = 2f;
    public float tiempoIdle = 0f;

    void Start() // Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //Application.targetFrameRate = 60;

        velocidadX = velocidad;
        oldVelocidadX = velocidadX;
    }





    void Update() // Update is called once per frame
    {
 

        if (Input.GetKey(KeyCode.A))
        {
            //if left
 
            if (transform.position.x > xLeftLimit.position.x)
            {
                AxisLeft();
            }
        }

        else if (Input.GetKey(KeyCode.D)) {
            //if right
            if (transform.position.x < xRightLimit.position.x)
            {
                AxisMoveR();
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < yMax)
            {
                VerticalMoveUP();
            }
        }

        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > yMin)
            {
                VerticalMoveDOWN();
            }

        }
            animator.SetFloat("Speed", Mathf.Abs(velocidadX));
            //1 o -1, es necesario multiplicarlo para que alcance una velocidad más notoria        
            //vector2 es el tipo de vector(R2)/velocidadResultante es el nombre del vector creado

        }


    void AxisMoveR()
    {
        transform.position += transform.right * Time.deltaTime * velocidadX;
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    void AxisLeft() {
        transform.position += transform.right * Time.deltaTime * velocidadX;
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    void VerticalMoveUP()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y +velocidad*Time.deltaTime , transform.position.z);
    }

    void VerticalMoveDOWN() 
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - velocidad*Time.deltaTime , transform.position.z);
    }
    /*
    void FlipAxis()
    {
        if (velocidadX < -0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (velocidadX > 0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
    */
}
