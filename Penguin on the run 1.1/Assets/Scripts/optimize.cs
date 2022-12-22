using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optimize : MonoBehaviour
{   
    public float Ydistance = 5.1f;
    
    void Update()
    {
        if (transform.position.y > 5.1) {
            Destroy(gameObject);
        }
    }
}
