using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerState
{
    public PlayerDoubleJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.Collider.enabled = false;

        player.SetVelocity(0f, player.doubleJumpForce);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();

        player.Collider.enabled = true;
    }

}
