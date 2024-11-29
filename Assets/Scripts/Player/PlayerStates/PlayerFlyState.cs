using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlyState : PlayerState
{
    public PlayerFlyState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    float defaultGravityScale;
    float stateTimer = 0f;

    public override void Enter()
    {
        base.Enter();

        stateTimer = player.flyTime;


        player.IsFlying = true;
        player.HelicopterActivate(true);

        player.SetVelocity(rb.velocity.x, player.flySpeed);

        player.Collider.enabled = false;

        defaultGravityScale = rb.gravityScale;
        rb.gravityScale = 0f;
        
    }

    public override void Exit()
    {
        base.Exit();

        player.IsFlying = false;
        player.HelicopterActivate(false);

        player.SetVelocity(rb.velocity.x, 0);
       
        player.Collider.enabled = true;

        rb.gravityScale = defaultGravityScale;
    }

    public override void Update()
    {
        base.Update();

        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            stateMachine.ChangeState(player.FallState);
        }
        else 
        {
            player.SetVelocity(rb.velocity.x, player.flySpeed);
        }
    }
}
