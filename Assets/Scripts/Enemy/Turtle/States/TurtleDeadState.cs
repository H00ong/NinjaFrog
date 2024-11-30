public class TurtleDeadState : EnemyState
{
    Enemy_Turtle turtle;
    public TurtleDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Turtle _turtle) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.turtle = _turtle;
    }

    public override void Enter()
    {
        turtle.Collider.enabled = false;

        base.Enter();

        turtle.SetVelocity(0, turtle.dieJumpForce);
        turtle.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
