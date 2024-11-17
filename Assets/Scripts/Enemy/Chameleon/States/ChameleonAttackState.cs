using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonAttackState : EnemyState
{
    Enemy_Chameleon chameleon;

    public ChameleonAttackState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Chameleon _chameleon) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.chameleon = _chameleon;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        chameleon.animationTrigger = false;
    }

    public override void Update()
    {
        if (chameleon.animationTrigger) 
        {
            stateMachine.ChangeState(chameleon.IdleState);
        }
    }
}
