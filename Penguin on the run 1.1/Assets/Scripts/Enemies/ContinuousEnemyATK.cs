using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousEnemyATK : MonoBehaviour
{
    [SerializeField] private float EnemyATK = -1f; //1 para tener un mínimo en default
    private bool isPlayerAttacked = false;
   

    private GameObject playerHealth;
    public float cooldown;
    private float contarTiempo = 0;


    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        if (isPlayerAttacked)
        {
            contarTiempo += Time.deltaTime; //contar tiempo
        }
        if (contarTiempo > cooldown)
        {
            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK); //luego de un tiempo pega, y vuelve a contar
            contarTiempo = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) //si isTrigger fue activado por el "playerHitbox" entonces "enemyWeapon" hará dmg al Player
        {
            isPlayerAttacked = true;


        }

        if (other.CompareTag("playerWaterHitbox"))
        {
            isPlayerAttacked = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerAttacked = false;
    }



}