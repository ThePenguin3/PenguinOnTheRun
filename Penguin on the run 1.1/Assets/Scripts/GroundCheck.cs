using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    
    public bool isGrounded = false;

    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collider)
    {
        //isGrounded = collider != null && ((( 1 << collider.gameObject.layer) & platformLayerMask) != 0);
        if (collider.CompareTag("Ground")) { isGrounded = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
