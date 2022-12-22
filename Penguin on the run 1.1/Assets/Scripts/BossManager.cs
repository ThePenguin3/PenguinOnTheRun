using UnityEngine;

public class BossManager : MonoBehaviour
{
    public string bossName;
    BossHealthBar bossHealthBar;
    EnemyHealth enemyStats;

    private void Awake() 
    {   
        bossHealthBar = FindObjectOfType<BossHealthBar>();
        enemyStats = GetComponent<EnemyHealth>();
    }
    private void Start()
    {
        bossHealthBar.SetBossName(bossName);
                 
    }
}