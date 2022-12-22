using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoAnimado : MonoBehaviour
{

    [SerializeField] private Vector2 backSpeed;
    private Vector2 offset;
    private Material material;


    private Rigidbody2D playerrb;

    void Awake() 
    {
        material = GetComponent<SpriteRenderer>().material;
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }


    
    private void Update()
    {
        offset = 0.1f * playerrb.velocity.x * Time.deltaTime * backSpeed;
        material.mainTextureOffset += offset;
    }
}
