using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bunny : Enemy
{
    [SerializeField] public float jumpForce = 5f;
    [SerializeField] public float idleTime = 2f;
    [SerializeField] public float groundRadius = 0.2f;
    [SerializeField] Transform bunnyFootPos;

    #region States
    public BunnyMoveState MoveState { get; private set; }
    public BunnyJumpState JumpState { get; private set; }
    public BunnyIdleState IdleState { get; private set; }
    public BunnyDeadState DeadState { get; private set; }
    public BunnyFallState FallState { get; private set; }

    #endregion

    protected override void Start()
    {
        base.Start();

        MoveState = new BunnyMoveState(this, StateMachine, "Move", this);
        JumpState = new BunnyJumpState(this, StateMachine, "Jump", this);
        FallState = new BunnyFallState(this, StateMachine, "Fall", this);
        IdleState = new BunnyIdleState(this, StateMachine, "Idle", this);
        DeadState = new BunnyDeadState(this, StateMachine, "Dead", this);

        StateMachine.InitializeState(IdleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(bunnyFootPos.position, groundRadius);

    }
    public bool GroundCheck()
    {
        return Physics2D.CircleCast(bunnyFootPos.position, groundRadius, Vector2.down, 0f, groundLayer);
    }

    public override void Die()
    {
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }
}
