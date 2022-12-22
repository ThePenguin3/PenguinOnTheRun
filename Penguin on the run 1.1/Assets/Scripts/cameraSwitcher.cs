using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraSwitcher : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cam;
    

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {   
        
        if (other.CompareTag("Player")) {
            cam.enabled = false; //con esto debería apagar la cam1 y pondría la cam del boss
        }
        
    }




}
