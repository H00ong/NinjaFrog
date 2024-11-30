using UnityEngine;

public class BatReturnState : EnemyState
{
    Enemy_Bat bat;
    Transform player;

    public BatReturnState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
    }

    public override void Enter()
    {
        bat.FlyFlipCheck(bat.defaultPos);

        base.Enter();
    }

    public override void Exit()
    {
        bat.playerDetect = false;
        bat.canFollow = false;

        base.Exit();
    }

    public override void Update()
    {
        bat.transform.position = Vector2.MoveTowards(bat.transform.position, bat.defaultPos.position, bat.followingSpeed * Time.deltaTime);

        float distance = Vector2.Distance(bat.transform.position, bat.defaultPos.position);

        if (distance < 0.1f)
        {
            bat.transform.position = bat.defaultPos.position;
            stateMachine.ChangeState(bat.InState);
            return;
        }
    }
}
