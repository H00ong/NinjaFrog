using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyIdleState : EnemyState
{
    Enemy_Bunny bunny;

    private float stateTimer;

    public BunnyIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();

        bunny.SetVelocity(0);

        stateTimer = bunny.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0) 
        {
            stateMachine.ChangeState(bunny.MoveState);
        }
    }
}
