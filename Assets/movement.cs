using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 v;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    }

    void FixedUpdate()
    {
        rb.linearVelocity = v * speed;
    }
}