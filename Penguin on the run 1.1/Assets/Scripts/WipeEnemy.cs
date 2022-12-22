using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeEnemy : MonoBehaviour
{
    //unicamente usado en el nivel 4 para eliminar lo que escape de la pantalla
    [SerializeField] private float wiped = -9999f;



    public bool isEnemyAttacked = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //si el proyectil entra en hitbox enemigo
        {


            isEnemyAttacked = true;

            //EnemyHealth
            other.GetComponent<EnemyHealth>().UpdateHealth(wiped);

        }
    }

}
