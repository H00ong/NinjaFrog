using UnityEngine;

public class BatFollowState : EnemyState
{
    Enemy_Bat bat;

    float stateTimer = 0f;
    Transform player;

    public BatFollowState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = bat.followTime;
        player = bat.player;
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
            stateMachine.ChangeState(bat.ReturnState);
            return;
        }

        bat.FlyFlipCheck(player);

        bat.transform.position = Vector2.MoveTowards(bat.transform.position, player.position, bat.followingSpeed * Time.deltaTime);
    }
}
