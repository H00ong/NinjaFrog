using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatInState : EnemyState
{
    Enemy_Bat bat;

    public BatInState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
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
        stateMachine.ChangeState(bat.IdleState);
    }
}
