using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    private void Update()
    {
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        GameObject lowestGround = grounds[0];

        foreach (GameObject ground in grounds)
        {
            if (ground.transform.position.y < lowestGround.transform.position.y)
            {
                lowestGround = ground;
            }
        }

        transform.position = lowestGround.transform.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Player>().Die();
        }        
    }
}
