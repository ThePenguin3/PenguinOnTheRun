using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterHealth : MonoBehaviour
{

    [SerializeField] private GameObject Playerhitbox; // = playerHitbox


    public bool isWater = false;

    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private float currentHealth = 0f;
    public HealthBar healthBar;
    private Animator animator; //for setTrigger Death

    public GameObject canvas;
    private bool attacked = false; //player shouldn't take dmg all the time

    private bool alreadyDead = false;

    [SerializeField] private bool enemy;//if enemy is true then enemy is attacking player
    // Start is called before the first frame update
    void Start()
    {
        //Playerhitbox = GameObject.FindWithTag("playerHITBOX").transform.Find("playerHITBOX").gameObject;
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);

        currentHealth = maxHealth;
        canvas.SetActive(false);
        healthBar.SetMaxHealth(currentHealth);


    }

    private void Update()
    {
        if (alreadyDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            canvas.SetActive(true);
        }
    }



    public void UpdatePlayerHealth(float mod) //esta funcion es llamada por enemyATK para aplicar el cambio de currentHP
    {
        if (!attacked)//si no has recibido dmg
        {
            currentHealth += mod; //suma el mod(asume que ser� negativo para que baje hp)

            if (currentHealth <= 0 && !alreadyDead)
            {
                //corre animacion de muerte
                animator.SetTrigger("isDead");
                waterController wcc = GetComponent<waterController>();
                

                wcc.enabled = false;
                if (isWater)
                {
                    waterAttack wATK = GetComponent<waterAttack>();
                    wATK.enabled = false;
                }

                else if (!isWater) {
                    SkyAttack skyATK = GetComponent<SkyAttack>();
                    skyATK.enabled = false;
                    
                }
                alreadyDead = true;

            }
            else if (mod < 0 && enemy) //si el mod es negativo y hecho por el enemigo
            {
                attacked = true; //ya recibi� una vez el ataque, hasta que el proximo isTrigger sea activado por hacer contacto con hitbox de ataque enemigo
            }
            else if (currentHealth > maxHealth) //si por alguna razon te curaste
            {
                currentHealth = maxHealth;//que no exceda
            }
            healthBar.SetHealth(currentHealth);
        }
    }
}
