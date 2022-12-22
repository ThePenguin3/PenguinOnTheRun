using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyPatrolHigh : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public Transform leftPoint, rightPoint;
    public float moveSpeed = 0f;

    private bool movingRight;

    public GameObject player;
    public bool inRange = false;
    private bool canAttackk = true;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        movingRight = true;


        leftPoint.parent = null; //luego de tomar el valor los separa para que la distancia sea fija
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));

        if (!inRange)
        {

            if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

        }

        else {
            if (canAttackk)
            {
                if (inRange)
                {
                    animator.SetBool("attacking", true);
                }
            }
        }



    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //float direction = Mathf.Atan(player.transform.position.y / player.transform.position.x);
            
            float form = (player.transform.position.x - gameObject.transform.position.x);
            if (form < 0.1)
            {
                //Debug.Log("player might be on the left");
                transform.eulerAngles = new Vector3(0f, 0f, 0f); //left
                
            }
            else if (form > 0.1)
            {
                //Debug.Log("player might be on the right");
                transform.eulerAngles = new Vector3(0f, 180f, 0f); //requires change to turn right, 180f applied
                
            }

            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }


    private IEnumerator Cooldown(float attackCooldown)
    {
        canAttackk = false;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(attackCooldown);
        canAttackk = true;
    }

    
 
}

