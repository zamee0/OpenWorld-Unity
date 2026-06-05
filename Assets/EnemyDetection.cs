using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private EnemyChase enemy;

    void Start()
    {
        enemy =
            GetComponentInParent<EnemyChase>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            enemy.SetPlayerDetected(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            enemy.SetPlayerDetected(false);
        }
    }
}