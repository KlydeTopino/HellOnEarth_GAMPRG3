using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float baseAttack;
    public float attackRadius;
    public float attackSpeed;
    public float canAttack = 0f;

    public LayerMask whatIsPlayer;

    public Transform player;

    public bool isFlipped = false;
    private bool isInAttackRange;

    public PlayerHealth PlayerHealthScript;

    public Vector3 attackOffset;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        PlayerHealthScript = player.GetComponent<PlayerHealth>();       
    }

    void Update()
    {
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
    }


    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack()
    {
        /*if (isInAttackRange && player != null)
        {
            if (attackSpeed <= canAttack)
            {
                PlayerHealthScript.currentHealth -= baseAttack;
                Debug.Log("Attack Player");
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }*/
      
       Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRadius, whatIsPlayer);
        if (colInfo != null)
        {
            //colInfo.GetComponent<PlayerHealth>().TakeDamage(baseAttack);
            PlayerHealthScript.currentHealth -= baseAttack;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }
}
