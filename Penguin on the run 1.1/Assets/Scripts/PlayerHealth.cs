using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("soloClickSiEsNivel1")]
    public bool nivel1 = false;
    [SerializeField] private GameObject Playerhitbox; // = playerHitbox
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] public float currentHealth = 0f;
    public HealthBar healthBar;
    private Animator animator; //for setTrigger Death
    
    
    private bool attacked = false; //player shouldn't take dmg all the time

    public bool alreadyDead = false;
    public GameObject canvas;
    [SerializeField] private bool enemy;//if enemy is true then enemy is attacking player
    // Start is called before the first frame update
    void Start()
    {
        //Playerhitbox = GameObject.FindWithTag("playerHITBOX").transform.Find("playerHITBOX").gameObject;
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        canvas.SetActive(false);

    }

   

    
    private void Update()
    {
        if (alreadyDead){
            if(Input.GetKeyDown(KeyCode.R)){
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
                animator.SetBool("isDead",true);
                Controller cc = GetComponent<Controller>();
                cc.enabled = false;
                PlayerSlide dash = GetComponent<PlayerSlide>();
                dash.enabled = false;
                playerJump jumpAbility = GetComponent<playerJump>();
                jumpAbility.enabled = false;

                if (nivel1)
                {
                    NerfedAttack nerfAtk = GetComponent<NerfedAttack>();
                    nerfAtk.enabled = false;
                }
                else
                {
                    Attack pAtk = GetComponent<Attack>();
                     //no se podr� mover

                    pAtk.enabled = false; //ni disparar
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
