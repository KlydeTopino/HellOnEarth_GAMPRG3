using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;

    public float chaseRadius;
    public float attackRadius;
    private float canAttack = 0f;
    private float attackSpeed = .5f;

    public PlayerHealth PlayerHealthScript;

    private bool isInAttackRange;
    private bool isInChaseRange;

    public LayerMask whatIsPlayer;

    public Animator undeadAnimator;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        PlayerHealthScript = target.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, chaseRadius, whatIsPlayer);
        if (health <= 0)
        {
            Death();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (isInChaseRange && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            undeadAnimator.SetBool("isMoving", true);
            undeadAnimator.SetBool("withinRange", false);
            undeadAnimator.SetFloat("MoveX", (-target.position.x - (-transform.position.x)));
            undeadAnimator.SetFloat("MoveY", (target.position.x - (transform.position.x)));
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
        }

        if (!isInChaseRange)
        {
            undeadAnimator.SetBool("isMoving", false);
        }

        if (isInAttackRange)
        {
            if (attackSpeed <= canAttack)
            {
                undeadAnimator.SetBool("withinRange", true);
                undeadAnimator.SetBool("isMoving", false);
                PlayerHealthScript.TakeDamage(baseAttack);
                Debug.Log("Attack Player");
                canAttack = 0f;
            }
            else
            {
                undeadAnimator.SetBool("withinRange", false);
                //undeadAnimator.SetBool("isAttackOnCooldown", false);               
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chaseRadius);
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
