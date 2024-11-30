using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected float dieDelay;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject, dieDelay);
    }
}
