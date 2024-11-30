using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected string animBoolName;

    protected Rigidbody2D rb;
    protected Animator anim;

    public EnemyState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _Enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        anim = enemy.Anim;
        rb = enemy.Rb;

        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        if (enemy.FlipCheck())
        {
            enemy.Flip();
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }

}
