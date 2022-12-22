using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTarget : MonoBehaviour
{
    // script for bullet

    public GameObject player;
    private bool ready = false;
    public float waitTime;
    private bool stop = false;
    public float bullet_speed; //usar la misma velocidad del script enemyproyectile

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(Cooldown(waitTime));
        StartCoroutine(Stopbullet(waitTime / 2));
        /*
        Vector3 direction = player.transform.position - transform.position;

        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, apuntar);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) {
            transform.position -= bullet_speed * Time.deltaTime * transform.right;
        }
        if (ready)
        {
            stop = false;
            Vector3 direction = player.transform.position - transform.position;
            float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, apuntar);
            ready = false;
        }
    }


    private IEnumerator Cooldown(float waitTime)
    {
        ready = false;
        
        yield return new WaitForSeconds(waitTime);
        ready = true;
    }

    private IEnumerator Stopbullet(float waitTime2)
    {
        stop = false;

        yield return new WaitForSeconds(waitTime2);
        stop = true;
    }


}
