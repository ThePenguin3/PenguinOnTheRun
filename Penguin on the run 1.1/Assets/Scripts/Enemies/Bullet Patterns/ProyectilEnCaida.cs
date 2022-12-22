using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnCaida : MonoBehaviour
{

    public float EnemyATK = -1f; //1 para tener un mínimo en default


    //private float direction = 1f;

    [SerializeField] private float bulletTime = 10f; //tiempo de existencia de la bala

    [SerializeField] private GameObject playerHealth; //obtener vida del player

    public bool isPlayerAttacked = false;
    public float bullet_speed = 2f;

    public GameObject impactEffect;

    private bool goesup;
    public float timer = 2f;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, bulletTime); //luego de X segundos en existencia la bala será destruida

        StartCoroutine(GoUp(timer));
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += -1 * bullet_speed * Time.deltaTime * transform.right;

        if (goesup == true) {
            transform.position += new Vector3(0f, 0.1f, 0f);
        }

        
        if (goesup == false)
        {
            transform.position += new Vector3(0f, -0.01f, 0f);
        }
        

        //transform.position += new Vector3(0f, 5*Time.deltaTime*Mathf.Sin(Time.time*10)+(0.005f), 0f); //actual position + new position (la bala sube/baja (funcion seno))
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("playerHitbox")) //si isTrigger fue activado por el "playerHitbox" entonces "enemyWeapon" hará dmg al Player
        {
            isPlayerAttacked = true;
            
            playerHealth.GetComponent<PlayerHealth>().UpdatePlayerHealth(EnemyATK); //aplica el daño del enemigo sobre el player
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        else if (other.CompareTag("Ground"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }


    private IEnumerator GoUp(float timer)
    {
        goesup = true;
        yield return new WaitForSeconds(timer);
        goesup = false;
    }


}
