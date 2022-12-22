using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetOnce : MonoBehaviour
{

    public float EnemyATK = -1f; //1 para tener un m�nimo en default


    //private float direction = 1f;

    [SerializeField] private float bulletTime = 10f; //tiempo de existencia de la bala

    [SerializeField] private GameObject playerHealth; //obtener vida del player

    public bool isPlayerAttacked = false;
    public float bullet_speed = -2f;



    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, bulletTime); //luego de X segundos en existencia la bala ser� destruida

        
        Vector3 direction = playerHealth.transform.position - transform.position;

        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, apuntar);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += bullet_speed * Time.deltaTime * transform.right; //this moves the bullet (no mover)

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) //si isTrigger fue activado por el "playerHitbox" entonces "enemyWeapon" har� dmg al Player
        {
            isPlayerAttacked = true;

            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK); //aplica el da�o del enemigo sobre el player
        }

        if (other.CompareTag("playerWaterHitbox"))
        {
            isPlayerAttacked = true;
            playerHealth.GetComponent<WaterHealth>().UpdatePlayerHealth(EnemyATK); //aplica el da�o del enemigo sobre el player
        }
    }

}
