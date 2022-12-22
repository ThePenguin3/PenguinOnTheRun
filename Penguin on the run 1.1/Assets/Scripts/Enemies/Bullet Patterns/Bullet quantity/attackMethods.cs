using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackMethods : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject attackPrefab;
    public GameObject attackPrefab2; //opcional
    public GameObject attackPrefab3;

    public Transform firePoint;
    public Transform firePoint2;

    public int bullets = 3;
    public int bullets2 = 3;
    public int bullets3 = 50;

    [Header("opcional")]
    public GameObject missilePrefab;
    public Transform player;
    public float tiempoEntreMisil = 0.1f;
    public float tiempoEntreBala;
    public float tiempoEntreBala2;
    public int cantidadDeMisiles = 5;
    public float distanciaXshot = 3f;

    public float tiempoEntreBala3;
    public Transform firePoint3;

    [Header("para misil")]
    public float distanciaWarningY = 2.45f;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    public void BulletHell() {

        for (int i = 0; i < bullets; i++) {
            Instantiate(attackPrefab, firePoint.position+ new Vector3(0f,(float)i,0f), firePoint.rotation);
        }
    }


    public void BulletHellez()
    {

        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position + new Vector3(0f, (float)i/3, 0f), firePoint.rotation);
        }
    }



    public IEnumerator DelayInstantiateBH()
    {
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position + new Vector3(0f, (float)i, 0f), firePoint.rotation);
            if (i < 3) { yield return new WaitForSeconds(0.15f); }
            else
            {
                yield return new WaitForSeconds(0.10f);
            }
        }
    }

    public IEnumerator DelayInstantiateSwordfishATK()
    {
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
            if (i < 3) { yield return new WaitForSeconds(0.15f); }
            else
            {
                yield return new WaitForSeconds(tiempoEntreBala);
            }
        }
    }


    public IEnumerator DelayInstantiateoneShot()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(attackPrefab, firePoint.position + new Vector3(0f, (float)i, 0f), firePoint.rotation);
            yield return new WaitForSeconds(0.15f);
            
        }
    }

    public void BulletHellRound() {
        float number = 360f / bullets;
        

        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, number * i));
        }
        
    }

    public IEnumerator DelayInstantiate()
    {
        float number = 360f / bullets;
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i));
            if (i < 3) { yield return new WaitForSeconds(0.20f); }
            else
            {
                yield return new WaitForSeconds(0.10f);
            }
        }
    }


    public void BulletHell_halfRound()
    {
        float number = 180f / bullets;

        for (int i = 0; i < bullets; i++)
        {
 
             Instantiate(attackPrefab, firePoint.position+new Vector3(1f*i,0f,0f), firePoint.rotation * Quaternion.Euler(0f, 0f, number * i));
            
        }

    }

    public IEnumerator DelayInstantiateBHhalf()
    {
        float number = 180f / bullets;
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position, Quaternion.Euler(0f, 0f, number * i));
            yield return new WaitForSeconds(0.4f);
            

        }
    }

    public IEnumerator DelayInstantiatecrossShot()
    {
        
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position + new Vector3(0f,0.5f,0f), firePoint.rotation);
            Instantiate(attackPrefab2, firePoint.position + new Vector3(0f, -0.5f, 0f), firePoint.rotation);
            yield return new WaitForSeconds(0.4f);


        }
    }



    public IEnumerator DelayInstantiateMissile()
    {

        for (int i = 0; i < cantidadDeMisiles; i++)
        {
            Instantiate(missilePrefab, new Vector3(player.position.x, transform.position.y-distanciaWarningY,-0.1f), player.rotation); //el impact ocurrira en la pos del player
            
            yield return new WaitForSeconds(tiempoEntreMisil); //tiempo entre instancia


        }
    }


    public void Xshot() {
        //usar pos del Player

        Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot, distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 0f)); //cuadrante 1
        Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 90f)); //cuadrante 2
        Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, -distanciaXshot, 0f), Quaternion.Euler(0f,0f,180f)); //cuadrante 3
        Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot, -distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 270f)); //cuadrante 4
    }

    public IEnumerator DelayInstantiateXShot() {

        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot, distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 0f)); //cuadrante 1
            Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 90f)); //cuadrante 2
            Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, -distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 180f)); //cuadrante 3
            Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot, -distanciaXshot, 0f), Quaternion.Euler(0f, 0f, 270f)); //cuadrante 4

            yield return new WaitForSeconds(tiempoEntreBala); //tiempo entre instancia
        }
    }

    public IEnumerator DelayInstantiate4thBossATK()
    {

        float number = 360f / bullets;
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i));
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i));
            yield return new WaitForSeconds(tiempoEntreBala);
        }


    }

    public IEnumerator DelayInstantiateExtraTarget() {

        for (int i = 0; i < bullets2; i++)
        {
            Instantiate(attackPrefab2, firePoint2.position, firePoint.rotation);
            yield return new WaitForSeconds(tiempoEntreBala/5);

        }
    }

    public IEnumerator DelayInstantiate4thBossBURST()
    {

        float number = 360f / bullets3;
        for (int i = 0; i < bullets3; i++)
        {
            Instantiate(attackPrefab3, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i));
            Instantiate(attackPrefab3, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i));
            yield return new WaitForSeconds(tiempoEntreBala);
        }


    }

    public void arrowShower() {
        
        Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot*2, 7f, -0.3f), Quaternion.identity);
        Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, 7f, -0.3f), Quaternion.identity);
        Instantiate(attackPrefab, player.position + new Vector3(0f, 7f, -0.3f), Quaternion.identity);
        Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot, 7f, -0.3f), Quaternion.identity);
        Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot*2, 7f, -0.3f), Quaternion.identity);
    }

    public IEnumerator DelayInstantiateArrowShower()
    {

        for (int i = 0; i < bullets; i++)
        {
            if (i % 2 == 0)
            {
                Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, 7f, -0.3f) + new Vector3(distanciaXshot/2,0f,0f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot/2, 7f, -0.3f) + new Vector3(distanciaXshot / 2, 0f, 0f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(-1f, 7f, -0.3f) + new Vector3(distanciaXshot / 2, 0f, 0f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot/2, 7f, -0.3f) + new Vector3(distanciaXshot / 2, 0f, 0f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3((distanciaXshot) - 2, 7f, -0.3f) + new Vector3(distanciaXshot / 2, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot, 7f, -0.3f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(-distanciaXshot / 2, 7f, -0.3f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(-1f, 7f, -0.3f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3(distanciaXshot / 2, 7f, -0.3f), Quaternion.identity);
                Instantiate(attackPrefab, player.position + new Vector3((distanciaXshot) - 2, 7f, -0.3f), Quaternion.identity);
            }
            yield return new WaitForSeconds(tiempoEntreBala);

        }
    }


    public IEnumerator DelayInstantiate5thBossQuickATK()
    {

        float number = 360f / bullets;
        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i+90));
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i + 270));
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i + 180));
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i ));

            yield return new WaitForSeconds(tiempoEntreBala);
        }
    }


    public IEnumerator DelayInstantiate5ThBossSlowATK() {
        float number = 360f / bullets2;
        for (int i = 0; i < bullets2; i++)
        {
            Instantiate(attackPrefab2, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i + 90));
            Instantiate(attackPrefab2, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i + 270));
            Instantiate(attackPrefab2, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i + 180));
            Instantiate(attackPrefab2, firePoint.transform.position, Quaternion.Euler(0f, 0f, -number * i));


            yield return new WaitForSeconds(tiempoEntreBala2);
        }
    }



    public IEnumerator DelayInstantiateShots()
    {

        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(tiempoEntreBala);


        }
    }

    //exact copy of ? but different type of bullets
    public IEnumerator DelayInstantiate2ndShots()
    {

        for (int i = 0; i < bullets2; i++)
        {
            Instantiate(attackPrefab2, firePoint2.position, firePoint2.rotation);
            yield return new WaitForSeconds(tiempoEntreBala2);

        }
    }
    public IEnumerator DelayInstantiate3rdShots()
    {

        for (int i = 0; i < bullets3; i++)
        {
            Instantiate(attackPrefab3, firePoint3.position + new Vector3(0f,0f,-0.5f), firePoint3.rotation);
            yield return new WaitForSeconds(tiempoEntreBala3);

        }
    }


    public IEnumerator DelayInstantiate4Hojas()
    {

        float number = 360f / bullets2;
        for (int i = 0; i < bullets2; i++)
        {
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, number * i + 90));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, number * i + 270));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, number * i + 180));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, number * i));

            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, -number * i + 90));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, -number * i + 270));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, -number * i + 180));
            Instantiate(attackPrefab2, firePoint2.transform.position, Quaternion.Euler(0f, 0f, -number * i));


            yield return new WaitForSeconds(tiempoEntreBala2);
        }
    }


    public IEnumerator DelayInstantiateQuickATK3thShots()
    {

        float number = 360f / bullets3;
        for (int i = 0; i < bullets3; i++)
        {
            Instantiate(attackPrefab3, firePoint3.transform.position, Quaternion.Euler(0f, 0f, number * i + 90));
            Instantiate(attackPrefab3, firePoint3.transform.position, Quaternion.Euler(0f, 0f, number * i + 270));
            Instantiate(attackPrefab3, firePoint3.transform.position, Quaternion.Euler(0f, 0f, number * i + 180));
            Instantiate(attackPrefab3, firePoint3.transform.position, Quaternion.Euler(0f, 0f, number * i));

            yield return new WaitForSeconds(tiempoEntreBala3);
        }
    }


    public IEnumerator DelayRound1stShots() {


        float number = 360f / bullets;

        for (int j = 0; j < bullets/3; j++)
        {
            for (int i = 0; i < bullets; i++) // this makes a circle as its made almost instantly
            {
                Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, number * i));

            }
            //this is how many circles
            yield return new WaitForSeconds(tiempoEntreBala);

        }

    }

    

    public void TargetRound1stShots() {
        float number = 360f / bullets;
        Vector3 direction = player.transform.position - transform.position;

        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        for (int i = 0; i < bullets; i++) // this makes a circle as its made almost instantly
        {
            Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, firePoint.rotation.z+apuntar+number * i));
        }
    }   

    
    public IEnumerator DelayInstantiateTarget1Shots()
    {
        
        Vector3 direction = player.transform.position - firePoint.position;
        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        for (int i = 0; i < bullets; i++)
        {
            Instantiate(attackPrefab, firePoint.position, Quaternion.Euler(0f,0f,firePoint.rotation.z+apuntar));
            yield return new WaitForSeconds(tiempoEntreBala);


        }
    }
    

    public IEnumerator DelayInstantiateRoundTarget1Shots()
    {
        float number = 360f / bullets;
       

        Vector3 direction = player.transform.position - transform.position;
        float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

        for (int i = 0; i < bullets; i++)
        {   

            Instantiate(attackPrefab, firePoint.position, Quaternion.Euler(0f, 0f, firePoint.rotation.z + apuntar + number * i));
            yield return new WaitForSeconds(tiempoEntreBala);


        }
    }

    

    public IEnumerator DelayDoubleRoundTarget1stShots()
    {
        
        float number = 360f / bullets;


        for (int j = 0; j < bullets / 3; j++)
        {
            for (int i = 0; i < bullets; i++) // this makes a circle as its made almost instantly
            {
                Vector3 direction = player.transform.position - transform.position;
                float apuntar = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;

                Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, apuntar+number * i));
                Instantiate(attackPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, 180+apuntar+number * i));
                yield return new WaitForSeconds(tiempoEntreBala / 10);
            }
            //this is how many circles
            yield return new WaitForSeconds(tiempoEntreBala);

        }

    }

}
