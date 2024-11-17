using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turtle : Enemy
{
    public float idleTime = 3f;
    public float moveTime = 5f;
    public float spikeInTime = .5f;
    public float spikeOutTime = .5f;

    #region States

    public TurtleIdleState IdleState { get; set; }
    public TurtleMoveState MoveState { get; set; }
    public TurtleDeadState DeadState { get; set; }
    public TurtleSpikeInState SpikeInState { get; set; }
    public TurtleSpikeOutState SpikeOutState { get; set; }

    #endregion

    protected override void Start()
    {
        base.Start();

        IdleState = new TurtleIdleState(this, StateMachine, "Idle", this);
        MoveState = new TurtleMoveState(this, StateMachine, "Move", this);
        DeadState = new TurtleDeadState(this, StateMachine, "Dead", this);
        SpikeInState = new TurtleSpikeInState(this, StateMachine, "In", this);
        SpikeOutState = new TurtleSpikeOutState(this, StateMachine, "Out", this);

        StateMachine.InitializeState(MoveState);
    }

    public override void Die()
    {
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

}
