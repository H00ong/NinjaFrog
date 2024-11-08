using UnityEngine;

public class DeathPlane : Trap
{
    [SerializeField] Vector3 offset;

    private void Update()
    {
    }

    public void UpdatePosition(Transform _lowestGround)
    {
        transform.position = _lowestGround.position + offset;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Player>().Die();
        }        
    }
}
