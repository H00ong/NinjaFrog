using UnityEngine;

public class Enemy_Bat : Enemy
{
    [Header("Move Details")]
    public float returnSpeed = .8f;
    public float followingSpeed = 1f;
    public float idleTime = 3f;
    public float followTime = 3f;

    [Header("State Info")]
    public bool playerDetect = false;
    public bool isReturning = false;
    public bool canFollow = false;

    public Transform defaultPos;
    public Transform player;

    #region States

    public BatOutState OutState { get; private set; }
    public BatInState InState { get; private set; }
    public BatIdleState IdleState { get; private set; }
    public BatReturnState ReturnState { get; private set; }
    public BatFollowState FollowState { get; private set; }
    public BatDeadState DeadState { get; private set; }

    #endregion

    protected override void Start()
    {
        base.Start();

        Rb.gravityScale = 0;
        enemyLayer = LayerMask.GetMask("FlyingEnemy");

        OutState = new BatOutState(this, StateMachine, "Out", this);
        InState = new BatInState(this, StateMachine, "In", this);
        IdleState = new BatIdleState(this, StateMachine, "Idle", this);
        ReturnState = new BatReturnState(this, StateMachine, "Move", this);
        FollowState = new BatFollowState(this, StateMachine, "Move", this);
        DeadState = new BatDeadState(this, StateMachine, "Dead", this);

        defaultPos.position = transform.position;

        StateMachine.InitializeState(IdleState);
    }

    public void FlyFlipCheck(Transform _player)
    {
        if (transform.position.x < _player.position.x)
        {
            if (FacingDir == -1)
            {
                Flip();
            }
        }
        else
        {
            if (FacingDir == 1)
            {
                Flip();
            }
        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
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
}
