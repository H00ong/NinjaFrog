using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{
    #region States
    public SlimeMoveState MoveState { get; private set; }
    public SlimeDeadState DeadState { get; private set; }

    #endregion

    protected override void Start()
    {
        base.Start();

        MoveState = new SlimeMoveState(this, StateMachine, "Move", this);
        DeadState = new SlimeDeadState(this, StateMachine, "Dead", this);

        StateMachine.InitializeState(MoveState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

}
