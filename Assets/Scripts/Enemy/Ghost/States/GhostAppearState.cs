using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GhostAppearState : EnemyState
{
    Enemy_Ghost ghost;

    float stateTimer = 0f;

    public GhostAppearState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Ghost _ghost) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.ghost = _ghost;
    }

    public override void Enter()
    {
        ghost.transform.localPosition = new Vector2(Random.Range(-ghost.xPosRange, ghost.xPosRange), ghost.transform.localPosition.y);

        if (Probability.IsEventHappened(.5f)) 
            ghost.Flip();


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
            stateMachine.ChangeState(ghost.IdleState);
        }
    }
}
