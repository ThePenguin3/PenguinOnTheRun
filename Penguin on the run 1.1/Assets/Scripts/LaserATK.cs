using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserATK : MonoBehaviour
{
    
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public Transform firePoint8;

    public Transform player;

    public GameObject laserPrefab;

    public float bullets4 = 10f;

    public float tiempoEntreLaser = 0.1f;

    public IEnumerator LaserSpiderWeb() {
        float number = 360f / bullets4;
        Vector3 direction = player.transform.position - firePoint4.position;
        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        for (int i = 0; i < bullets4; i++)
        {
            Instantiate(laserPrefab, firePoint4.position, Quaternion.Euler(0f, 0f, firePoint4.rotation.z +apuntar+number*i));
            Instantiate(laserPrefab, firePoint5.position, Quaternion.Euler(0f, 0f, firePoint5.rotation.z + apuntar + number * i));
            Instantiate(laserPrefab, firePoint6.position, Quaternion.Euler(0f, 0f, firePoint6.rotation.z + apuntar + number * i));
            Instantiate(laserPrefab, firePoint7.position, Quaternion.Euler(0f, 0f, firePoint7.rotation.z + apuntar + number * i));
            Instantiate(laserPrefab, firePoint8.position, Quaternion.Euler(0f, 0f, firePoint8.rotation.z + apuntar + number * i));
            yield return new WaitForSeconds(tiempoEntreLaser);
            
        }
    }


}

