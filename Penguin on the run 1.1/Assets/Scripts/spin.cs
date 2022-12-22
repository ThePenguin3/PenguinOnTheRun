using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float value = 1f;
    void Update()
    {   
        transform.rotation = Quaternion.Euler(0f, 0f, value*Time.time);

    }
}
