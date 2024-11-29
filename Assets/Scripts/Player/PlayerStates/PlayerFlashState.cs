using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashState : PlayerState
{
    public PlayerFlashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        player.SetVelocity(0, 0);

        player.IsFlashing = true;
        player.Collider.enabled = false;
        player.Rb.gravityScale = 0f;
        player.Tr.emitting = true;

        player.flashTrigger = false;
        player.animationFinished = false;

        base.Enter();
    }
    public override void Update()
    {
        // base.Update();

        if (player.flashTrigger)
        {
            player.Flash();
            player.flashTrigger = false;
        }

        if (player.animationFinished) 
        {
            stateMachine.ChangeState(player.FallState);
        }
    }

    public override void Exit()
    {
        player.IsFlashing = false;
        player.Collider.enabled = true;
        player.Rb.gravityScale = 1f;
        player.Tr.emitting = false;

        player.animationFinished = false;

        base.Exit();
    }
}
