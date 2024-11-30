using UnityEngine;

public class PlantIdleState : EnemyState
{
    Enemy_Plant plant;
    float stateTimer;

    public PlantIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Plant _plant) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.plant = _plant;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = plant.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(plant.AttackState);
            return;
        }

        if (plant.FlipCheck())
        {
            plant.Flip();
        }
    }
}
