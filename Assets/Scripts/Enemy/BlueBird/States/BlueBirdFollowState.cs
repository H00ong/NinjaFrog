using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BlueBirdFollowState : EnemyState
{
    Enemy_BlueBird blueBird;
    Transform player;

    public BlueBirdFollowState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_BlueBird _blueBird) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.blueBird = _blueBird;
    }

    public override void Enter()
    {
        base.Enter();

        player = blueBird.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        blueBird.FlyFlipCheck(player);
        
        blueBird.transform.position = Vector2.MoveTowards(blueBird.transform.position, blueBird.player.position, blueBird.followingSpeed * Time.deltaTime);

        float distance1 = Vector2.Distance(blueBird.transform.position, blueBird.patrolPoints[0].position);
        float distance2 = Vector2.Distance(blueBird.transform.position, blueBird.patrolPoints[1].position);

        float playerDistance = Vector2.Distance(blueBird.transform.position, blueBird.player.position);

        float distance = Mathf.Min(distance1, distance2);

        if (distance > blueBird.returnDistance || playerDistance > blueBird.returnDistance)
        {
            stateMachine.ChangeState(blueBird.ReturnState); 
        }
    }
}
