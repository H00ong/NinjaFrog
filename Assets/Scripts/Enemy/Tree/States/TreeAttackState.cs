public class TreeAttackState : EnemyState
{
    Enemy_Tree tree;
    public TreeAttackState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Tree _tree) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.tree = _tree;
    }

    public override void Enter()
    {
        base.Enter();
        tree.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();

        tree.animationTrigger = false;
    }

    public override void Update()
    {
        if (tree.animationTrigger)
        {
            stateMachine.ChangeState(tree.IdleState);
        }
    }
}
