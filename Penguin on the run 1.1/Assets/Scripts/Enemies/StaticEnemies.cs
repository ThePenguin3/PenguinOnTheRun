using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemies : MonoBehaviour
{
    // contraparte del script Attack
    

    public Animator animator;
    public BoxCollider2D boxcollider2d;


    public bool canAttackk = true; //delay
    public bool inRange = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (canAttackk)
            {
                animator.SetBool("attacking", true);

            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
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
