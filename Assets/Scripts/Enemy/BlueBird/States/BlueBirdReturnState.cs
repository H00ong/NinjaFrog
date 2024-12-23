using UnityEngine;

public class BlueBirdReturnState : EnemyState
{
    Enemy_BlueBird blueBird;
    bool lastFlip = false;
    public BlueBirdReturnState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_BlueBird _blueBird) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.blueBird = _blueBird;
    }

    public override void Enter()
    {
        blueBird.isReturning = true;
        lastFlip = false;

        blueBird.FlyFlipCheck(blueBird.patrolPoints[blueBird.destinationPointIndex]);

        base.Enter();
    }

    public override void Exit()
    {
        blueBird.isReturning = false;
        blueBird.playerDetect = false;

        if (lastFlip == true)
        {
            blueBird.Flip();
        }

        base.Exit();
    }

    public override void Update()
    {
        float distance = Vector2.Distance(blueBird.transform.position, blueBird.patrolPoints[blueBird.destinationPointIndex].position);

        if (distance <= .1f)
        {
            blueBird.transform.position = new Vector2(blueBird.transform.position.x, blueBird.defaultBlueBirdYPos);
            stateMachine.ChangeState(blueBird.IdleState);
        }
        else
        {
            blueBird.transform.position = Vector2.MoveTowards(blueBird.transform.position,
                                                              blueBird.patrolPoints[blueBird.destinationPointIndex].position,
                                                              Time.deltaTime * blueBird.returnSpeed);
        }
    }
}
