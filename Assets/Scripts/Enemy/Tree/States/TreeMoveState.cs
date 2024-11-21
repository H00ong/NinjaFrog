using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMoveState : EnemyState
{
    Enemy_Tree tree;

    public TreeMoveState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Tree _tree) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.tree = _tree;
    }

    public override void Enter()
    {
        base.Enter();

        tree.SetVelocity(tree.moveSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (enemy.FlipCheck())
        {
            enemy.Flip();
            stateMachine.ChangeState(tree.AttackState);
        }
    }
}
