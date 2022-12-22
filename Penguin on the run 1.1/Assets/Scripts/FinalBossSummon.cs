using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossSummon : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject enemy4;

    [SerializeField] private GameObject enemy5;
    [SerializeField] private GameObject enemy6;


    private float BossHealth = -1;

    //? para evitar que vuelva a correr esa linea
    private bool firstSet = false;
    private bool secondSet = false;
    private bool thirdSet = false;
    private GameObject Boss;

    private void Start()
    {
        Boss = GameObject.Find("DarkLord");
        BossHealth = Boss.GetComponent<EnemyHealth>().currentHealth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        BossHealth = Boss.GetComponent<EnemyHealth>().currentHealth;

        if (BossHealth < 1000 && !firstSet)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            firstSet = true;
        }
        else if (BossHealth < 800 && !secondSet)
        {
            enemy3.SetActive(true);
            enemy4.SetActive(true);
            secondSet = true;
        }

        else if (BossHealth < 550 && !thirdSet) 
        {
            enemy5.SetActive(true);
            enemy6.SetActive(true);
            thirdSet = true;
        }
    }
}
