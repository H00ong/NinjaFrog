using UnityEngine;

public class TurtleMoveState : EnemyState
{
    Enemy_Turtle turtle;

    float stateTimer = 0f;

    public TurtleMoveState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Turtle _turtle) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.turtle = _turtle;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = turtle.moveTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        stateTimer -= Time.deltaTime;

        if (stateTimer < 0)
        {
            turtle.SetVelocity(0);
            stateMachine.ChangeState(turtle.SpikeInState);
            return;
        }

        turtle.SetVelocity(turtle.moveSpeed);
    }
}
