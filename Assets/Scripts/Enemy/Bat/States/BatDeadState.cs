public class BatDeadState : EnemyState
{
    Enemy_Bat bat;

    public BatDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _bat) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.bat = _bat;
    }

    public override void Enter()
    {
        base.Enter();

        bat.Collider.enabled = false;
        bat.SetVelocity(0, bat.dieJumpForce);

        rb.gravityScale = 1;

        bat.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
