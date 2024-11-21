using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlantAttackState : EnemyState
{
    Enemy_Plant plant;
    public PlantAttackState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Plant _plant) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.plant = _plant;
    }

    public override void Enter()
    {
        base.Enter();

        if (plant.FlipCheck()) 
        {
            plant.Flip();
        }

        if(plant.player != null)
            plant.shootingDir = (plant.player.position - plant.shootingPos.position).normalized;
        else
            plant.shootingDir = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();

        plant.animationTrigger = false;
        plant.shootingDir = Vector2.zero;
    }

    public override void Update()
    {
        if (plant.animationTrigger) 
        {
            stateMachine.ChangeState(plant.IdleState);
        }
    }
}
