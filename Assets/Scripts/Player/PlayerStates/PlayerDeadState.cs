using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) :
        base(_player, _stateMachine, _animBoolName) { } 

    public override void Enter()
    {
        base.Enter();

        player.Collider.enabled = false;
        rb.gravityScale = 0f;
    }

    public override void Update()
    {
        player.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
