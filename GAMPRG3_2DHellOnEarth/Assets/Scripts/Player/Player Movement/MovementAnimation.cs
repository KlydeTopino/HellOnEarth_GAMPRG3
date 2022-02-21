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
        animator.SetFloat("Horizontal", playerScript.MovementInput.x);
        animator.SetFloat("Vertical", playerScript.MovementInput.y);
        animator.SetFloat("Speed", playerScript.MovementInput.sqrMagnitude);
    }
}
