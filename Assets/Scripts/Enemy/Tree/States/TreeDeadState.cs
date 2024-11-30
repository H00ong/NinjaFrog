public class TreeDeadState : EnemyState
{
    Enemy_Tree tree;
    public TreeDeadState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Tree _tree) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.tree = _tree;
    }

    public override void Enter()
    {
        tree.SetVelocity(0, tree.dieJumpForce);
        tree.Collider.enabled = false;

        base.Enter();

        tree.DieEffect();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
