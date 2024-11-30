using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Fly();
            Destroy(gameObject);
        }
    }
}
