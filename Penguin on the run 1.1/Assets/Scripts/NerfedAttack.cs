using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfedAttack : MonoBehaviour
{
    
    [Header("Proyectil de nivel1")]
    public Transform firePoint; //posicion de origen del proyectil (0.233Y position)
    

    [SerializeField] GameObject bulletPrefab;
    

    public Animator animator;
    public bool canFire = true;

    public GameObject player;

    public bool playerAttack = false;



    void Update()
    {
        if (!IsGrounded())
        {  //if in the air
            animator.SetBool("bGround", false);
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (canFire)
                {
                    playerAttack = true;
                    animator.SetTrigger("FlyingATK");
                }
            }
        }

        else
        { //not in the air
            animator.SetBool("bGround", true);
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (canFire == true) //la unica condicion para poder disparar es la recarga
                {
                    playerAttack = true;
                    animator.SetTrigger("isAttackTrigger");
                }
            }
        }

   

    }
    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }



    public void ShootProjectile()
    {   //spawn bulletPrefab
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //(bullet to spawn, origin position, rotation)


        //this by itself won't move the bullet but will spawn the object and give direction 
    }

    

    private IEnumerator RangedCooldown(float attackCooldown)
    {
        canFire = false;
        yield return new WaitForSeconds(attackCooldown);
        canFire = true;
    }

  
}

