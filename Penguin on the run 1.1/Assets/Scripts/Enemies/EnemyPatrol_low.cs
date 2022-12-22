using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol_low : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public Transform leftPoint, rightPoint;
    public float moveSpeed = 0f;

    private bool movingRight;

    public bool canAttackk = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        movingRight = true;

    
        leftPoint.parent = null; //luego de tomar el valor los separa para que la distancia sea fija
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        
        if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb.velocity.y);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

    }



    private IEnumerator Cooldown(float attackCooldown)
    {
        canAttackk = false;
        animator.SetBool("ATK", false);
        yield return new WaitForSeconds(attackCooldown);
        canAttackk = true;
    }


}



    

