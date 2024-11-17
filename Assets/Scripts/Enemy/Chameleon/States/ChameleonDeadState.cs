using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonDeadState : EnemyState
{
    Enemy_Chameleon chameleon;
    public ChameleonDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Chameleon _chameleon) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.chameleon = _chameleon;
    }

    public override void Enter()
    {
        chameleon.Collider.enabled = false;
        chameleon.SetVelocity(0, chameleon.dieJumpForce);

        base.Enter();

        chameleon.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        
    }
}
