using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTransformSpeed : MonoBehaviour
{


    /*
     *  Enemy patrol script
     *  stands still until player enters its trigger
     *  requires a public float distance to stop moveSpeed
     *
     */
    [Header("ImpulsoATK(opcional)")]
    public bool ataqueRapido = false;
    public float ImpulsoATK = 0f; //opcional


    private Animator animator;

    private SpriteRenderer sr;


    [Header("StaticChase")]
    public float distanciaATK = 2f;

    public float moveSpeed = 0f;


    private bool inCHASErange;
    private bool movingRight;


    private GameObject player;
    private bool canAttackk = true;


    private bool inATKrange;


    public float distanciaMinimaChase = 1f;
    public float moveSpeedOld;
    private float form;
    private float distanciaMinimaChaseL = 1f;

    public bool hasBurst = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        movingRight = true;

        moveSpeed = moveSpeed * Time.deltaTime;



        distanciaMinimaChaseL = -1 * distanciaMinimaChase;
        moveSpeedOld = moveSpeed;


    }


    void Update()
    {
        form = (player.transform.position.x - gameObject.transform.position.x); //constantly calculate distance between enemy and player
        //player 2x - enemy 4x = -2x, negative form player left
        //player 6x - enemy 4x = 2x, positive form player right
        if (inCHASErange) //si esta en rango de chase, aplica velocidad
        {
            moveSpeed = moveSpeedOld;
        }

        else if (!inCHASErange) //si no esta en rango, quita la velocidad
        {
            moveSpeed = 0;
        }

        if (Mathf.Abs(form) < distanciaMinimaChase) //si esta muy cerca, quita la velocidad
        {
            moveSpeed = 0;
        }


        //esto debería hacerse cargo que darle direccion al enemigo {
        if (movingRight)
        {
            transform.position = moveSpeedOld * Time.deltaTime * transform.right;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            if (form < distanciaMinimaChaseL) //left
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = -moveSpeedOld * Time.deltaTime * transform.right;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (form > distanciaMinimaChase) //right
            {
                movingRight = true;
            }
        }
        // }



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
            //player entra en rango
            inCHASErange = true;
            //distancia entre el player y el enemigo con el script
            float absoluteForm = Mathf.Abs(form); //distancia como escalar
            if (form < 0.1) //left
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                if (absoluteForm < distanciaATK)
                {
                    inATKrange = true;
                }
                else
                {
                    inATKrange = false;
                }

            }
            else if (form > 0.1) //right
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f); //requires change to turn right, 180f applied

                if (absoluteForm < distanciaATK)
                {
                    inATKrange = true;
                }
                else
                {
                    inATKrange = false;
                }
            }


        }
    }



    private void OnTriggerExit2D(Collider2D other) //trigger para chase
    {
        if (other.CompareTag("Player"))
        {
            inCHASErange = false;
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
