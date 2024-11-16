using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDeadState : EnemyState
{
    Enemy_Bunny bunny;
    public BunnyDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();

        bunny.SetVelocity(0, bunny.dieJumpForce);
        bunny.Collider.enabled = false;

        bunny.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
