using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BatOutState : EnemyState
{
    Enemy_Bat bat;
    Transform player;
    public BatOutState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
    }

    public override void Enter()
    {
        player = bat.player;

        bat.FlyFlipCheck(player);

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        stateMachine.ChangeState(bat.FollowState);
    }
}
