using UnityEngine;

public class TreeIdleState : EnemyState
{
    Enemy_Tree tree;

    float stateTimer;

    public TreeIdleState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Tree _tree) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.tree = _tree;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = tree.idleTime;
        tree.SetVelocity(0);
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
            stateMachine.ChangeState(tree.MoveState);
            return;
        }
    }
}
