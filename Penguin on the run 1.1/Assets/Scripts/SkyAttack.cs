using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAttack : MonoBehaviour
{
    [Header("Proyectil")]
    public Transform firePoint; //posicion de origen del proyectil (0.233Y position)
    public Transform firePoint2;
    [SerializeField] GameObject bulletPrefab;


    public Animator animator;
    private bool canFire = true;



    public GameObject player;

    public bool playerAttack = false;

    
    void Update()
    {
        if (canFire == true) //la unica condicion para poder disparar es la recarga
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerAttack = true;
                animator.SetBool("ATK", true);
            }
        }

    }


    void ShootProjectileSky()
    {   
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint.rotation);
        
    }


    private IEnumerator RangedCooldown(float attackCooldown)
    {
        canFire = false;
        animator.SetBool("ATK", false);
        yield return new WaitForSeconds(attackCooldown);
        canFire = true;
    }
}