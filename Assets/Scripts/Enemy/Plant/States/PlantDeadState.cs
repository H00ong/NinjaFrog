using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDeadState : EnemyState
{
    Enemy_Plant plant;
    public PlantDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Plant _plant) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.plant = _plant;
    }

    public override void Enter()
    {
        plant.SetVelocity(0, plant.dieJumpForce);
        plant.Collider.enabled = false;

        base.Enter();

        plant.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
    }
}
