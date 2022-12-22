using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proyectile : MonoBehaviour
{


    [SerializeField]private float bullet_speed = 20f;
    [SerializeField]private float bullet_damage = -2f;

    //private float direction = 1f;

    [SerializeField]private float bulletTime = 10f;

    public GameObject impactEffect;

    public bool isEnemyAttacked = false;
    

    private void Start()
    {   

        Destroy(gameObject, bulletTime); //luego de 10s en existencia la bala será destruida
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.right * Time.deltaTime * bullet_speed ; //this moves the bullet (no mover)
        
        //transform.position += new Vector3(0f, 5*Time.deltaTime*Mathf.Sin(Time.time*10)+(0.005f), 0f); //actual position + new position (la bala sube/baja (funcion seno))
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //si el proyectil entra en hitbox enemigo
        {

            
            isEnemyAttacked = true;

            //EnemyHealth
            other.GetComponent<EnemyHealth>().UpdateHealth(bullet_damage);


            Destroy(gameObject); //destruye la bala
            Instantiate(impactEffect, transform.position, transform.rotation); // instanciar efecto de explosion
        }

        else if (other.CompareTag("Ground")) //choca con el escenario
        {
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }


    }


}
