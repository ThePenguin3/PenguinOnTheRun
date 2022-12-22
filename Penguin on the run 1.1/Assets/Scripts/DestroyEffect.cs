using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 2f;

    void Start()
    {
        Destroy(gameObject,timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
