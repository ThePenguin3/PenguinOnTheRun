using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticLavaGolem : MonoBehaviour
{
    // contraparte del script Attack

    [Header("Proyectil enemigo")]
    public Transform firePoint;
    [SerializeField] GameObject attackPrefab;

    public Animator animator;
    public BoxCollider2D boxcollider2d;
    public Transform playerPOS;

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
                animator.SetBool("GolemATK", true);

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

    public void LavaATK()
    {   
        for(int i = 0; i < 10; i++)
        {
            Instantiate(attackPrefab, firePoint.position + new Vector3(-2*i, 0f, 0f), firePoint.rotation);
        }
        
    }

    public void FirstShot()
    {
        Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
    }

    public void SecondShot()
    {
        Instantiate(attackPrefab, firePoint.position + new Vector3(-2f, 0f, 0f), firePoint.rotation);
    }

    public void ThirdShot()
    {
        Instantiate(attackPrefab, firePoint.position + new Vector3(-4f, 0f, 0f), firePoint.rotation);
    }

    public void FourShot() { Instantiate(attackPrefab, firePoint.position + new Vector3(-6f, 0f, 0f), firePoint.rotation); }

    public void LastShot() { Instantiate(attackPrefab, firePoint.position + new Vector3(-8f, 0f, 0f), firePoint.rotation); }


    private IEnumerator Cooldown(float attackCooldown)
    {
        canAttackk = false;
        animator.SetBool("GolemATK", false);
        yield return new WaitForSeconds(attackCooldown);
        canAttackk = true;
    }


    public IEnumerator DelayInstantiateLAVAATK()
    {
        int value = Random.Range(0, 2);//entre 0 y 1
        if (value == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(attackPrefab, firePoint.position + new Vector3(-i * 3f, 0f, 0f), firePoint.rotation);
                yield return new WaitForSeconds(0.25f);

            }
        }
        else if (value == 1) 
        {

            for (int i = 0; i < 10; i++)
            {
                Instantiate(attackPrefab, firePoint.position + new Vector3(-i * 3f, 0f, 0f)+new Vector3(1.5f,0f,0f), firePoint.rotation);
                yield return new WaitForSeconds(0.25f);

            }

        }
    }

}
