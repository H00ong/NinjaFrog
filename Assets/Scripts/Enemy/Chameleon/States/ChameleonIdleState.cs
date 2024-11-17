using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonIdleState : EnemyState
{
    Enemy_Chameleon chameleon;

    float stateTimer;

    public ChameleonIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Chameleon _chameleon) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.chameleon = _chameleon;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = chameleon.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(chameleon.MoveState);
        }
    }
}
