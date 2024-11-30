public class BunnyFallState : EnemyState
{
    Enemy_Bunny bunny;

    public BunnyFallState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (bunny.GroundCheck())
        {
            bunny.Flip();
            stateMachine.ChangeState(bunny.IdleState);
        }
    }
}
