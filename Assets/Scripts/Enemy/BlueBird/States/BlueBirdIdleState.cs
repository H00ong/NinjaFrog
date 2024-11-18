using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdIdleState : EnemyState
{
    Enemy_BlueBird blueBird;
    float stateTimer = 0f;

    public BlueBirdIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_BlueBird _blueBird) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.blueBird = _blueBird;
    }

    public override void Enter()
    {
        base.Enter();
        
        blueBird.SetVelocity(0);

        stateTimer = blueBird.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (blueBird.playerDetect && !blueBird.isReturning)
        {
            stateMachine.ChangeState(blueBird.FollowState);
            return;
        }

        stateTimer -= Time.deltaTime;

        if (stateTimer < 0) 
        {
            stateMachine.ChangeState(blueBird.PatrolState);
            return;
        }
    }
}
