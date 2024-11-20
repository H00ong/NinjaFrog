using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdDeadState : EnemyState
{
    Enemy_BlueBird blueBird;
    public BlueBirdDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_BlueBird _blueBird) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.blueBird = _blueBird;
    }

    public override void Enter()
    {
        base.Enter();

        blueBird.Collider.enabled = false;
        blueBird.SetVelocity(0, blueBird.dieJumpForce);

        rb.gravityScale = 1;

        blueBird.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
