public class BunnyDeadState : EnemyState
{
    Enemy_Bunny bunny;
    public BunnyDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bunny _bunny) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bunny = _bunny;
    }

    public override void Enter()
    {
        bunny.Collider.enabled = false;
        bunny.SetVelocity(0, bunny.dieJumpForce);

        base.Enter();

        bunny.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
