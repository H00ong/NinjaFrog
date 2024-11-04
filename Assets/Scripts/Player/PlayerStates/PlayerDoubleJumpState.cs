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
        player.Collider.enabled = false;
        
        base.Enter();

        player.SetVelocity(0f, player.doubleJumpForce);
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        player.Collider.enabled = true;
        
        base.Exit();
    }

}
