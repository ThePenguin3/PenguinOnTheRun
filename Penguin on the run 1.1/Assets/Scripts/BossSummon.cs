using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummon : MonoBehaviour
{

    [SerializeField] private string BossName;

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    [SerializeField] private GameObject enemy4;

    [SerializeField] private GameObject enemy5;
    [SerializeField] private GameObject enemy6;
    [SerializeField] private GameObject enemy7;

    [SerializeField] private GameObject enemy8;
    [SerializeField] private GameObject enemy9;


    [SerializeField] private float HP1st;
    [SerializeField] private float HP2st;
    [SerializeField] private float HP3st;
    [SerializeField] private float HP4th;
    [SerializeField] private float HP5th;
    [SerializeField] private float HP6th;
    [SerializeField] private float HP7th;

    [SerializeField] private float HP8th = -999;



    private float BossHealth = -1;

    //? para evitar que vuelva a correr esa linea
    private bool firstSet = false;
    private bool secondSet = false;
    private bool thirdSet = false;
    private bool forthSet = false;
    private bool fifthSet = false;
    private bool sixthSet = false;
    private bool seventhSet = false;
    private bool eighthSet = false;

    private GameObject Boss;

    private void Start()
    {
        Boss = GameObject.Find(BossName);
        BossHealth = Boss.GetComponent<EnemyHealth>().currentHealth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        BossHealth = Boss.GetComponent<EnemyHealth>().currentHealth;

        if (BossHealth < HP1st && !firstSet)
        {
            enemy1.SetActive(true);
            firstSet = true;
        }
        else if (BossHealth < HP2st && !secondSet)
        {
            enemy2.SetActive(true);
            secondSet = true;
        }

        else if (BossHealth < HP3st && !thirdSet)
        {
            enemy3.SetActive(true);
            thirdSet = true;
        }

        else if (BossHealth < HP4th && !forthSet)
        {
            enemy4.SetActive(true);
            forthSet = true;
        }

        else if (BossHealth < HP5th && !fifthSet)
        {
            enemy5.SetActive(true);
            fifthSet = true;
        }

        else if (BossHealth < HP6th && !sixthSet)
        {
            enemy6.SetActive(true);
            sixthSet = true;
        }

        else if (BossHealth < HP7th && !seventhSet)
        {
            enemy7.SetActive(true);
            seventhSet = true;
        }

        else if (BossHealth < HP8th && !eighthSet)
        {
            enemy8.SetActive(true);
            enemy9.SetActive(true);
            eighthSet = true;

        }
    }
}

