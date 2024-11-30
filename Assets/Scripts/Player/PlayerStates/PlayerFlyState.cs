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

        stateTimer = 0;

        player.IsFlying = true;
        player.HelicopterActivate(true);
        
        player.helicopterSlider.gameObject.SetActive(true);
        player.helicopterSlider.value = 0;

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

        stateTimer += Time.deltaTime;

        if (stateTimer >= player.flyTime)
        {
            player.helicopterSlider.value = 0;
            player.helicopterSlider.gameObject.SetActive(false);
            stateMachine.ChangeState(player.FallState);
        }
        else 
        {
            player.helicopterSlider.value = stateTimer / player.flyTime;
            player.SetVelocity(rb.velocity.x, player.flySpeed);
        }
    }
}
