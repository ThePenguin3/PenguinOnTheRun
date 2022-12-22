using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{   

    [SerializeField] public float EnemyATK = -1f; //1 para tener un mínimo en default
    public bool isPlayerAttacked = false;

    private GameObject playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) //si isTrigger fue activado por el "playerHitbox" entonces "enemyWeapon" hará dmg al Player
        {
            isPlayerAttacked = true;

            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK); //aplica el daño del enemigo sobre el player
        }

        if (other.CompareTag("playerWaterHitbox"))
        {
            isPlayerAttacked = true;
            playerHealth.GetComponent<WaterHealth>().UpdatePlayerHealth(EnemyATK); //aplica el daño del enemigo sobre el player
        }
    }

}
