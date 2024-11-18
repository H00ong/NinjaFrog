using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ghost : Enemy 
{
    [Header("Move details")]
    public float idleTime = 2f;
    public float ghostingTime = .3f;
    public float xPosRange = .5f;

    #region States

    public GhostIdleState IdleState { get; set; }
    public GhostAppearState AppearState { get; set; }
    public GhostDisappearState DisappearState { get; set; }
    public GhostDeadState DeadState { get; set; }
    #endregion

    protected override void Start()
    {
        base.Start();

        IdleState = new GhostIdleState(this, StateMachine, "Idle", this);
        AppearState = new GhostAppearState(this, StateMachine, "Appear", this);
        DisappearState = new GhostDisappearState(this, StateMachine, "Disappear", this);
        DeadState = new GhostDeadState(this, StateMachine, "Dead", this);

        StateMachine.InitializeState(IdleState);
    }

    public override void Die()
    {
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }
}
    
