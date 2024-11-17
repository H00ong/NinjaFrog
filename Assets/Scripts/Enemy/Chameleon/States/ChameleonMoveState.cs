using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonMoveState : EnemyState
{
    Enemy_Chameleon chameleon;

    public ChameleonMoveState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Chameleon _chameleon) : base(_Enemy, _stateMachine, _animBoolName)
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
    }

    public override void Update()
    {
        if (enemy.FlipCheck())
        {
            enemy.Flip();
            stateMachine.ChangeState(chameleon.AttackState);
            return;
        }
        chameleon.SetVelocity(chameleon.moveSpeed);       
    }
}
