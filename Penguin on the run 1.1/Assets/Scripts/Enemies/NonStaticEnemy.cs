using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStaticEnemy : MonoBehaviour
{
    // Start is called before the first frame update


    [Header("Proyectil enemigo")]
    public Transform firePoint;
    [SerializeField] GameObject attackPrefab;
    

    public void FireATK()
    {
        Instantiate(attackPrefab, firePoint.position, firePoint.rotation*Quaternion.Euler(0,0,-90f*Time.time));
    }

}
