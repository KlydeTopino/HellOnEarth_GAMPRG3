using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    public Animator animator;

    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = gameObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.MovementInput != Vector2.zero)
        {
            animator.SetFloat("X", playerScript.MovementInput.x);
            animator.SetFloat("-X", playerScript.MovementInput.y);
        }
        animator.SetFloat("Speed", playerScript.MovementInput.sqrMagnitude);
    }
}
