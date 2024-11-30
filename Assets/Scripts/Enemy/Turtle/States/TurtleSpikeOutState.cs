using UnityEngine;

public class TurtleSpikeOutState : EnemyState
{
    Enemy_Turtle turtle;

    float stateTimer = 0f;

    public TurtleSpikeOutState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Turtle _turtle) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.turtle = _turtle;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = turtle.spikeOutTime;
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
            stateMachine.ChangeState(turtle.MoveState);
        }
    }
}
