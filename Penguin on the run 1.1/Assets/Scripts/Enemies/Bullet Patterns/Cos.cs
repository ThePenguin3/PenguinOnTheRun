using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, 2f * Time.deltaTime * Mathf.Cos(Time.time * 5), 0f);
    }
}
