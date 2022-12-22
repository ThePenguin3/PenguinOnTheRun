using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperEnemyPatrol : MonoBehaviour
{
    
    // Objectivo del script
    //el enemigo se mueve entre 2 puntos, tiene un box collider2D para detectar al player
    //al detectar al player tomará su posicion actual una sola vez y luego regresará a su posicion original
    //existe una distancia minima para que el enemigo ataque al player

    
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float distanciaATK = 2f;

    public Transform leftPoint, rightPoint;
    public float moveSpeed = 0f;

    private bool movingRight;
    public float chaseSpeed = 0f; //opcional

    private GameObject player;
    public bool canAttackk = true;
    

    private bool inATKrange;
    private static float leftPointOld; //never change this value
    private static float rightPointOld;

    private float Lpoint;
    private float Rpoint;

    private static float moveSpeedOld;

    private void Awake()
    {
        moveSpeed *= Time.deltaTime;
        chaseSpeed *= Time.deltaTime;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
        movingRight = true;


        leftPointOld = leftPoint.position.x; //registrar sus puntos de patrol
        rightPointOld = rightPoint.position.x; //a
        moveSpeedOld = moveSpeed;

        leftPoint.parent = null; //luego de tomar el valor los separa para que la distancia sea fija
        rightPoint.parent = null;

        Lpoint = leftPoint.position.x;
        Rpoint = rightPoint.position.x;

    }


    void Update()
    {

        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
    


        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            if (transform.position.x > Rpoint)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (transform.position.x < Lpoint)
            {
                movingRight = true;
            }
        }

        if (canAttackk)
        {
            if (inATKrange)
            {
                animator.SetBool("ATK", true);
            }
            else
            {
                animator.SetBool("ATK", false);
            }
        }

        else if (!canAttackk) { animator.SetBool("ATK", false); }


    }


    private void OnTriggerStay2D(Collider2D other)
    {
        

        if (other.CompareTag("Player"))
        {
            //float direction = Mathf.Atan(player.transform.position.y / player.transform.position.x);
            
            float form = (player.transform.position.x - gameObject.transform.position.x);
            float absoluteForm = Mathf.Abs(form); //distancia como escalar
            if (form < 0.1)
            {
                //Debug.Log("player might be on the left");
                //si con esto el script ya sabe que el player esta en la izq, entonces le aplico velocidad desde aqui
                Lpoint = player.transform.position.x;
                
                moveSpeed = moveSpeedOld + chaseSpeed; //le subo un poco la velocidad para notar la diferencia
                transform.eulerAngles = new Vector3(0f, 0f, 0f); //left
                if (absoluteForm < distanciaATK)
                {
                    inATKrange = true;
                }
                else {
                    inATKrange = false;
                }

            }
            else if (form > 0.1)
            {
                //Debug.Log("player might be on the right");
                Rpoint = player.transform.position.x;
                moveSpeed = moveSpeedOld + chaseSpeed;
                transform.eulerAngles = new Vector3(0f, 180f, 0f); //requires change to turn right, 180f applied

                if (absoluteForm < distanciaATK)
                {
                    inATKrange = true;
                }
                else {
                    inATKrange = false;
                }
            }

            
        }
    }
    


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Lpoint = leftPointOld; //regresa a su patrol original
            Rpoint = rightPointOld;
            moveSpeed = moveSpeedOld;

            animator.SetBool("ATK", false);//si no te puede "ver" sería raro que ataque de todos modos
        }
    }


    private IEnumerator Cooldown(float attackCooldown)
    {
        canAttackk = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttackk = true;
    }




}
