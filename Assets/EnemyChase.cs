using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Transform player;

    private bool playerDetected;

    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject
            .FindGameObjectWithTag("Player")
            .transform;
    }

    void Update()
    {
        if(playerDetected)
        {
            moveDirection =
                (player.position - transform.position)
                .normalized;
        }
        else
        {
            moveDirection = Vector2.zero;
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