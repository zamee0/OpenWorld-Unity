using System.Runtime.InteropServices;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxhealth = 100f ; 
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRadius = 0.8f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private LayerMask enemyLayer;
    private float currentHealth; 

    private Rigidbody2D rb ;
    private Vector2 v;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxhealth ;
    }

    void Update()
    {
        v.x = Input.GetAxisRaw("Horizontal");
        v.y = Input.GetAxisRaw("Vertical");

        v.Normalize();

        animator.SetBool("isWalking", v != Vector2.zero);

        animator.SetFloat("InputX", v.x);
        animator.SetFloat("InputY", v.y);

        if (v != Vector2.zero)
        {
            animator.SetFloat("LastInputX", v.x);
            animator.SetFloat("LastInputY", v.y);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = v * speed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage ;
        if(currentHealth<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("player died") ;
    }

    private void Attack()
{
    Collider2D[] enemies =
        Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRadius,
            enemyLayer
        );

    foreach(Collider2D enemy in enemies)
    {
        EnemyChase enemyScript =
            enemy.GetComponentInParent<EnemyChase>();

        if(enemyScript != null)
        {
            enemyScript.TakeDamage(attackDamage);
        }
    }
}

    private void OnDrawGizmosSelected()
{
    if(attackPoint == null)
        return;

    Gizmos.DrawWireSphere(
        attackPoint.position,
        attackRadius
    );
}
}