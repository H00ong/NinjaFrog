using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyJumpState : EnemyState
{
    Enemy_Bunny bunny;

    float jumpTimer;

    public BunnyJumpState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();

        jumpTimer = 0.5f;

        bunny.SetVelocity(0, bunny.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0)
        {
            if (rb.velocity.y < 0)
            {
                stateMachine.ChangeState(bunny.FallState);
            }
        }

    }
}
