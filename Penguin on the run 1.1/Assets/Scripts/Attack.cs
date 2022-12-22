using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Proyectil")]
    public Transform firePoint; //posicion de origen del proyectil (0.233Y position)
    public Transform firePoint2;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject SpecialPrefab;

    public Animator animator;
    public bool canFire = true; //necesito hacerlo public para poder arrastrarlo a Controller

    public GameObject player;

    public bool playerAttack = false;
    public bool canSpecial = true;
    // Update is called once per frame


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

        if (Input.GetKeyDown(KeyCode.K)) //si presiona la tecla pregunta si puede disparar
        {
            if (canSpecial)
            {
                animator.SetBool("SPATK", true);
            }
        }

        //todo el tiempo revisa que el cooldown surta efecto
        if (!canSpecial) {
            animator.SetBool("SPATK", false);
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

    public void ShootSPProjectile()
    {   //spawn bulletPrefab
        Instantiate(SpecialPrefab, firePoint2.position, firePoint2.rotation); //(bullet to spawn, origin position, rotation)


        //this by itself won't move the bullet but will spawn the object and give direction 
    }


    private IEnumerator RangedCooldown(float attackCooldown)
    {
        canFire = false;
        yield return new WaitForSeconds(attackCooldown);
        canFire = true;
    }

    private IEnumerator Cooldown(float attackCooldown)
    {
        canSpecial = false;
        yield return new WaitForSeconds(attackCooldown);
        canSpecial = true;
    }

}
