using UnityEngine;

public class Enemy_Chameleon : Enemy
{
    [Header("Move details")]
    public float idleTime = 2f;

    public bool animationTrigger = false;

    #region States

    public ChameleonIdleState IdleState { get; private set; }
    public ChameleonMoveState MoveState { get; private set; }
    public ChameleonAttackState AttackState { get; private set; }
    public ChameleonDeadState DeadState { get; private set; }

    #endregion

    protected override void Start()
    {
        base.Start();

        IdleState = new ChameleonIdleState(this, StateMachine, "Idle", this);
        MoveState = new ChameleonMoveState(this, StateMachine, "Move", this);
        AttackState = new ChameleonAttackState(this, StateMachine, "Attack", this);
        DeadState = new ChameleonDeadState(this, StateMachine, "Dead", this);

        StateMachine.InitializeState(IdleState);
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
}
