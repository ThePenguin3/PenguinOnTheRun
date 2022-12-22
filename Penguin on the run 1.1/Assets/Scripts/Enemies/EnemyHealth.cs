using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth; //maxhp value for enemy
    [SerializeField] public float currentHealth; //hp actual
    [SerializeField] private Animator animator; //give access to animator to set it's death animation


    public float destroyTimer = 2f;

    public GameObject explosionPrefab;
    private bool attack = false; //enemy isn't being attacked all the time

    public GameObject burstEffect;

    public bool hasBurst = false; //poner de forma manual si tendra burst o no (trigger)
    public bool hasBurstBool = false; //variacion del hasBurst (bool)

    private bool alreadyDead = false;
    private bool alreadyBurst = false;

    public bool startBurst = false;//check to ignore start

    public float porcentajeBurst = 0.25f;

    [Header("BossTypeOnly")]
    public bool isBossType = false;
    public BossHealthBar UIBossHealthBar;


    [SerializeField] private bool player = false; //player is true if player is making an attack against enemy


    private void Awake()
    {
        currentHealth = maxHealth;
        if (hasBurstBool)
        {
            animator.SetBool("goCrazy", false);//por si acaso xd
        }

        if (startBurst) {
            animator.SetTrigger("burstMode");
        }

    }
    void Start()
    {

        if (isBossType)
        {
            UIBossHealthBar.SetMaxBossHealth(currentHealth, maxHealth);
            animator.SetFloat("HP",currentHealth);
        }

    }


    public void UpdateHealth(float mod) //esta funcion es llamada por proyectile para aplicar el cambio de currentHP
    {
        if (!attack)//si no ha sido atacado ya
        {   

            currentHealth += mod; //suma el mod(asume que sera negativo para que baje hp)
            
            if (currentHealth <= 0 && !alreadyDead) //si es menor a 0 && not dead
            {
                Die();
                Destroy(gameObject, destroyTimer);//destruye al enemigo que trae este script
                alreadyDead = true; //prevenir que vuelva a entrar y ocurran bugs raros xd

            }
            else if (mod < 0 && player) //si el mod es negativo y player true
            {
                attack = true; //entonces ocurrio un ataque
            }
            else if ((currentHealth <= maxHealth * porcentajeBurst) && !alreadyBurst) //si la vida es menor a X %
            {
                if (hasBurst)
                {
                    BurstMode();
                    alreadyBurst = true; //prevenir que vuelva a entrar
                }

                if (hasBurstBool){
                    BurstModeBool();

                }

            }

            if (isBossType)
            {
                if (alreadyDead)
                {
                    UIBossHealthBar.SetBossHealthBarInactive();
                }
                UIBossHealthBar.SetBossHealth(currentHealth);
                animator.SetFloat("HP", currentHealth);

            }
        }


    }




    private void BurstMode()
    {
        animator.SetTrigger("burstMode");
    }

    private void BurstModeBool()
    {
        animator.SetBool("goCrazy", true);
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
    }

    public void CallExplosion() //usar en el animator para complementar la animacion de muerte
    {
        Instantiate(explosionPrefab, transform.position + new Vector3(0f, 0f, -0.5f), Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isBossType) //entra si es boss
        {

            if (other.CompareTag("playerHitbox")) //lo que entro es un playerHitbox
            {//prende las barras
                UIBossHealthBar.SetBossHealthBarActive();
            }

            else if (other.CompareTag("playerWaterHitbox"))
            {//sirve para water como para sky
                UIBossHealthBar.SetBossHealthBarActive();
            }
        }
    }


}
