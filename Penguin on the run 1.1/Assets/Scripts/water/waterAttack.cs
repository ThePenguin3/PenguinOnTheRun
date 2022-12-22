using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterAttack : MonoBehaviour
{
    [Header("Proyectil")]
    public Transform firePoint; //posicion de origen del proyectil (0.233Y position)
    [SerializeField] GameObject bulletPrefab;


    public Animator animator;
    public bool canFire = true; //necesito hacerlo public para poder arrastrarlo a Controller

    
    private float attackCooldown = 2f;

    public GameObject player;

    public bool playerAttack = false;

    // Update is called once per frame


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
      


    void EndShoot()
    {
        StartCoroutine(RangedCooldown(attackCooldown));
    }


    void ShootProjectile()
    {   //spawn bulletPrefab
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //(bullet to spawn, origin position, rotation)

        //this by itself won't move the bullet but will spawn the object and give direction 
    }


    private IEnumerator RangedCooldown(float attackCooldown)
    {
        canFire = false;
        animator.SetBool("ATK", false);
        yield return new WaitForSeconds(attackCooldown);
        canFire = true;
    }
}
