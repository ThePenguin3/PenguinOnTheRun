using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public Rigidbody2D rb;
    public TrailRenderer tr;
    public Animator animator;

    public bool canDash = true;
    private bool isDashing;

    
    public float dashingTime = 0.25f;
    public float dashingCooldown = 1f;


    // Update is called once per frame
    void Update()
    {
        if (isDashing) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDash) {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetBool("isDashing", true);

        rb.velocity = Vector2.up * 0;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        
        isDashing = false;
        animator.SetBool("isDashing", false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    private void FixedUpdate()
    {
        if (isDashing) {
            return;
        }
    }

}
