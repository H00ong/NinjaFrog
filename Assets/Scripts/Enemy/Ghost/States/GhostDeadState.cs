using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeadState : EnemyState
{
    Enemy_Ghost ghost;

    public GhostDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Ghost _ghost) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.ghost = _ghost;
    }   

    public override void Enter()
    {
        base.Enter();

        ghost.SetVelocity(0, ghost.dieJumpForce);
        ghost.Collider.enabled = false;

        ghost.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
