using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Move Info")]
    public float moveSpeed = 3f;
    public float dieJumpForce = 5f;

    [Header("Ground Check")]
    public float groundCheckDistance = .3f;
    [SerializeField] protected Transform groundCheck;

    [Header("Death Effect")]
    public float alphaValue = .7f;
    public float alphaTime = .2f;

    protected LayerMask groundLayer;
    protected LayerMask enemyLayer;

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public Collider2D Collider { get; private set; }
    public SpriteRenderer Sr { get; private set; }
    #endregion

    #region StateMachine

    public EnemyStateMachine StateMachine { get; private set; }

    #endregion

    public int FacingDir { get; protected set; } // 1: Right, -1: Left

    protected virtual void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        enemyLayer = LayerMask.GetMask("Enemy");

        Sr = GetComponentInChildren<SpriteRenderer>();
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();

        FacingDir = Sr.flipX ? 1 : -1;
        StateMachine = new EnemyStateMachine();
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState.Update();
    }

    public virtual void Flip()
    {
        SetVelocity(0);
        FacingDir = -FacingDir;
        transform.Rotate(0, 180, 0);
    }

    public void SetVelocity(float _xSpeed, float _ySpeed = 0f)
    {
        Rb.velocity = new Vector2(FacingDir * _xSpeed, _ySpeed);
    }

    public virtual bool FlipCheck()
    {
        // FlipCheck() == true -> Flip()
        if (groundCheck != null)
            return !Physics2D.Linecast(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance), groundLayer);
        else
            return false;
    }

    protected virtual void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance));
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.LayerCheck(_layer: enemyLayer))
            {
                Die();
            }
            else
            {
                SetVelocity(0, 0);
                player.Die();
            }
        }
    }

    public virtual void Die()
    {
        ScoreManager.instance.AddEnemyScore();
    }

    public virtual void DieEffect()
    {
        StartCoroutine(Alpha());
    }

    protected virtual IEnumerator Alpha()
    {
        yield return new WaitForSeconds(alphaTime);

        Color color = Sr.color;
        color.a = alphaValue;
        Sr.color = color;
    }
}
