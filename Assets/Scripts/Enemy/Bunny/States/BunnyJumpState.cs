public class BunnyJumpState : EnemyState
{
    Enemy_Bunny bunny;

    public BunnyJumpState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        base.Enter();

        bunny.SetVelocity(0, bunny.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(bunny.FallState);
        }
    }
}
