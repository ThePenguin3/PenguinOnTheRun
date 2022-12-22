using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMissile : MonoBehaviour
{


    private bool ready = false;
    public float waitTime = 0.5f;
    public GameObject missilePrefab;

    void Start()
    {
        StartCoroutine(Cooldown(waitTime));
    }

    
    void Update()
    {
        if (ready) { 
            Instantiate(missilePrefab,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator Cooldown(float waitTime)
    {
        ready = false;

        yield return new WaitForSeconds(waitTime);
        ready = true;
    }
}
