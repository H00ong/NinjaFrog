using UnityEngine;

public class BatIdleState : EnemyState
{
    Enemy_Bat bat;
    float stateTimer = 0f;

    public BatIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = bat.idleTime;
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
            bat.canFollow = true;
        }

        if (bat.canFollow)
        {
            if (bat.playerDetect)
            {
                stateMachine.ChangeState(bat.OutState);
            }
        }
    }
}
