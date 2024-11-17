using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : EnemyState
{
    Enemy_Slime slime;
    
    public SlimeMoveState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Slime _slime) 
        : base(_Enemy, _stateMachine, _animBoolName)
    {
        slime = _slime;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        slime.SetVelocity(slime.moveSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

}
