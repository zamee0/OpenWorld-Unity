using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float maxhealth = 60 ;
    [SerializeField] private float attackRange = 1f;

    [SerializeField] private int attackDamage = 10;
    private float attackCooldown = 1f;
private float attackTimer;
    private float currentHealth ; 

    private Rigidbody2D rb;
    private Transform player;
    private Animator animator ;

    private bool playerDetected;

    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject
            .FindGameObjectWithTag("Player")
            .transform;
        
        animator = GetComponent<Animator>() ;
        currentHealth  = maxhealth ;
    }

    void Update()
    {
        if(playerDetected)
        {
            moveDirection = (player.position - transform.position).normalized;
        }
        else
        {
            moveDirection = Vector2.zero;
        }

        animator.SetBool("is_move", moveDirection != Vector2.zero);

    animator.SetFloat("MoveX", moveDirection.x);
    animator.SetFloat("MoveY", moveDirection.y);

    if (moveDirection != Vector2.zero)
    {
        animator.SetFloat("LastX", moveDirection.x);
        animator.SetFloat("LastY", moveDirection.y);
    }

    float distance =
    Vector2.Distance(
        transform.position,
        player.position
    );

    if(distance <= attackRange)
    {
        Attack();
    }

    attackTimer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        rb.linearVelocity =
            moveDirection * moveSpeed;
    }

    public void SetPlayerDetected(bool value)
    {
        playerDetected = value;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth<= 0)
        {
            Destroy(gameObject) ;
        }
    }

    private void Attack()
{
    if(attackTimer < attackCooldown)
        return;

    attackTimer = 0;

    player
        .GetComponent<movement>()
        .TakeDamage(attackDamage);
}

}