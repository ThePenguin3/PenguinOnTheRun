using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilDiagonal : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyATK = -1f; //1 para tener un mínimo en default


    //private float direction = 1f;

    [SerializeField] private float bulletTime = 10f; //tiempo de existencia de la bala

    [SerializeField] private GameObject playerHealth; //obtener vida del player

    public bool isPlayerAttacked = false;
    public float bullet_speed = -2f;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        Destroy(gameObject, bulletTime); //luego de X segundos en existencia la bala será destruida
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bullet_speed * Time.deltaTime * transform.right; //this moves the bullet (no mover)
        transform.position += bullet_speed * Time.deltaTime * transform.up;
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
