using UnityEngine;

public class GhostDisappearState : EnemyState
{
    Enemy_Ghost ghost;
    float stateTimer = 0f;

    public GhostDisappearState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Ghost _ghost) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.ghost = _ghost;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = ghost.ghostingTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(ghost.AppearState);
        }
    }
}
