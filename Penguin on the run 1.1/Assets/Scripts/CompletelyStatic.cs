using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletelyStatic : MonoBehaviour
{
    


    private Animator animator;
    private SpriteRenderer sr;


    [Header("totally static")]
    public float distanciaParaATK = 13f;
    public float distanciaParaATKY = 13f;
    //private float distanciaATK = 1f;


    private bool movingRight;


    private GameObject player;
    private bool canAttackk = true;




    public float distanciaMinimaChase = 1f;
    private float form;
    private float distanciaMinimaChaseL = 1f;


    void Start()
    { 
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        movingRight = true;




        distanciaMinimaChaseL = -1 * distanciaMinimaChase;


    }


    void Update()
    {
        
        form = (player.transform.position.x - gameObject.transform.position.x); //constantly calculate distance between enemy and player
        float formY = player.transform.position.y - gameObject.transform.position.y;
        
        //esto debería hacerse cargo que darle direccion al enemigo {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            if (form < distanciaMinimaChaseL) //left
            {
                movingRight = false;
            }
        }
        else
        {
          
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            if (form > distanciaMinimaChase) //right
            {
                movingRight = true;
            }
        }

        if (canAttackk)
        {
            if (Mathf.Abs(form)< distanciaParaATK && Mathf.Abs(formY) < distanciaParaATKY)
            {
                animator.SetBool("ATK", true);
            }
            else {
                animator.SetBool("ATK", false);
                    
                    }
                
        }
        else if (!canAttackk)
            {
                animator.SetBool("ATK", false);
            }
    }


    private IEnumerator Cooldown(float attackCooldown)
    {
        canAttackk = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttackk = true;
    }


}

