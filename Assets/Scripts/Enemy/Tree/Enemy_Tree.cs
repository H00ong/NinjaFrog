using UnityEngine;

public class Enemy_Tree : Enemy
{
    [Header("Move Details")]
    public float idleTime = 2f;

    [Header("Attack Info")]
    public float attackDelay = .15f;
    public float bulletSpeed = 3f;
    public float bulletLifeTime = 4f;
    public GameObject bullet;
    [SerializeField] Transform shootingPos;

    public bool animationTrigger = false;
    #region States
    public TreeIdleState IdleState { get; private set; }
    public TreeMoveState MoveState { get; private set; }
    public TreeDeadState DeadState { get; private set; }
    public TreeAttackState AttackState { get; private set; }
    #endregion

    protected override void Start()
    {
        base.Start();

        IdleState = new TreeIdleState(this, StateMachine, "Idle", this);
        MoveState = new TreeMoveState(this, StateMachine, "Move", this);
        DeadState = new TreeDeadState(this, StateMachine, "Dead", this);
        AttackState = new TreeAttackState(this, StateMachine, "Attack", this);

        StateMachine.InitializeState(MoveState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, shootingPos.position, Quaternion.identity);
        newBullet.transform.localRotation = transform.localRotation;
        newBullet.GetComponent<Rigidbody2D>().velocity = -newBullet.transform.right * bulletSpeed;
        Destroy(newBullet, bulletLifeTime);
    }
}
