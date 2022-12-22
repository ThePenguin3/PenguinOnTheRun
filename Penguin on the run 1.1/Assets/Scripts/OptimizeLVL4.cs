using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeLVL4 : MonoBehaviour
{
    public float Ydistance = 5.1f;
    public float Ydistancemin;

    public float Xdistance;
    public float Xdistancemin;

    void Update()
    {
        if (transform.position.y > Ydistance || transform.position.y < Ydistancemin || transform.position.x > Xdistance || transform.position.x < Xdistancemin)
        {
            Destroy(gameObject);
        }


    }
}
