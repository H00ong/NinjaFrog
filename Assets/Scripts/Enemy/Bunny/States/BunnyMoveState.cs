using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMoveState : EnemyState
{
    Enemy_Bunny bunny;

    public BunnyMoveState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();

        bunny.SetVelocity(bunny.moveSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (enemy.FlipCheck())
        {
            stateMachine.ChangeState(bunny.JumpState);
        }
    }
}
