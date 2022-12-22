using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoanimadoAuto : MonoBehaviour
{

    [SerializeField] private Vector2 backSpeed;
    private Vector2 offset;
    private Material material;


    private Rigidbody2D playerrb;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }



    private void Update()
    {
        offset = 0.1f * Time.deltaTime * backSpeed;
        material.mainTextureOffset += offset;
    }
}
