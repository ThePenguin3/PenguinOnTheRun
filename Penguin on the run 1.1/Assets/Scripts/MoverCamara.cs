using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{

    //solo mueve la camara

    public float cameraSpeed = 1f; //usar valor positivo

    public Transform endPoint;
    

    
    void Update()
    {
        if (transform.position.x < endPoint.position.x)
        {
            transform.position += cameraSpeed * Time.deltaTime * transform.right;
        }
    }
}
