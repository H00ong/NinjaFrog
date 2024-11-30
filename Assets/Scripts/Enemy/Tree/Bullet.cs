using UnityEngine;

public class Bullet : Trap
{
    [SerializeField] float dieJumpForce;

    Rigidbody2D rb;
    Collider2D cd;
    SpriteRenderer sr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player.LayerCheck(LayerMask.GetMask("Bullet")))
            {
                this.Die();
                player.Jump();
            }
            else
            {
                player.Die();
            }
        }
    }

    protected override void Die()
    {
        rb.velocity = new Vector2(0, dieJumpForce);
        rb.gravityScale = 1f;

        cd.enabled = false;
        sr.color = new Color(1, 1, 1, 0.7f);
    }
}
