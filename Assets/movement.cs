using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 v;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        v.x = Input.GetAxisRaw("Horizontal");
        v.y = Input.GetAxisRaw("Vertical");
        v.Normalize() ;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = v * speed;
    }
}