using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWipe : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private BoxCollider2D wipeAll;

    private void Awake()
    {
        wipeAll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            wipeAll.enabled = true; //con esto debería vaciar el nivel al llegar al punto del jefe
        }

    }

}
