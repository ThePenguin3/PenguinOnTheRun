using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    // Este codigo sólo existirá en el animator

    [SerializeField] private BoxCollider2D Wall;



    public void WallEnabled() {
        Wall.enabled = true;
    }

    public void disableWall() {
        Wall.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            WallEnabled(); 
        }
        
    }

}
