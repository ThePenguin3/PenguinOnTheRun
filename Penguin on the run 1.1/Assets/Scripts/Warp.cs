using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] private BoxCollider2D warp2D;

    private void Awake()
    {
        warp2D.enabled = false;
        
    }



    public void EnableWall()
    {
        warp2D.enabled = true;
    }
}
