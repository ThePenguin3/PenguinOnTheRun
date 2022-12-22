using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpiral : MonoBehaviour
{


    public float EnemyATK = -1f; //1 para tener un mínimo en default


    //private float direction = 1f;

    [SerializeField] private float bulletTime = 10f; //tiempo de existencia de la bala

    [SerializeField] private GameObject playerHealth; //obtener vida del player

    public bool isPlayerAttacked = false;
    public float bullet_speed = -2f;



    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        transform.rotation = Quaternion.Euler(0f, 0f, 45f * Time.time);
        Destroy(gameObject, bulletTime); //luego de X segundos en existencia la bala será destruida

    }

    void Update()
    {

        transform.position += bullet_speed * Time.deltaTime * transform.right; //this moves the bullet (no mover)
        
        transform.rotation = Quaternion.Euler(0f, 0f, 45f * Time.time);

        //transform.position += new Vector3(0f, 5*Time.deltaTime*Mathf.Sin(Time.time*10)+(0.005f), 0f); //actual position + new position (la bala sube/baja (funcion seno))
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) //si isTrigger fue activado por el "playerHitbox" entonces "enemyWeapon" hará dmg al Player
        {
            isPlayerAttacked = true;

            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK); //aplica el daño del enemigo sobre el player
        }




    }
}
