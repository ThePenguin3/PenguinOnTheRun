using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilExplosion : MonoBehaviour
{
    [SerializeField] private float bullet_speed = 10f;
    

    

    public bool hasImpactEffect = false;
    public GameObject impactEffect;

    public float EnemyATK = -1f;


    

    [SerializeField] private float bulletTime = 10f; //tiempo de existencia de la bala

    [SerializeField] private GameObject playerHealth; //obtener vida del player

    public bool isPlayerAttacked = false;
    



    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        Destroy(gameObject, bulletTime); //luego de X segundos en existencia la bala será destruida

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * Time.deltaTime * bullet_speed;

      
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) 
        {
            isPlayerAttacked = true;

            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK);

            if (hasImpactEffect) {
                Instantiate(impactEffect, transform.position + new Vector3(0f, 0.5f, 1f), Quaternion.identity);
                Destroy(gameObject);
                    }
        }

        if (other.CompareTag("bulletDestroyer"))
        {   
            Destroy(gameObject);
            
        }

        if (other.CompareTag("playerWaterHitbox"))
        {
            isPlayerAttacked = true;
            playerHealth.GetComponent<WaterHealth>().UpdatePlayerHealth(EnemyATK);
        }

        if (other.CompareTag("Ground")) {
            Instantiate(impactEffect, transform.position+new Vector3(0f,0.5f,1f), Quaternion.identity);
            Destroy(gameObject);
        }
    }


}

