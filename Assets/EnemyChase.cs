using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

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
}