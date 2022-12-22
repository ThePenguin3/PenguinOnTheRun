using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{


    [SerializeField] public float Heal = 1f; //1 para tener un mínimo en default(usar valor+)
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

            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(Heal); //aplica el heal del enemigo sobre el player
            Destroy(gameObject);
        }

        if (other.CompareTag("playerWaterHitbox"))
        {
            isPlayerAttacked = true;
            playerHealth.GetComponent<WaterHealth>().UpdatePlayerHealth(Heal); //aplica el heal del enemigo sobre el player
            Destroy(gameObject);
        }
    }

}
