using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected string animBoolName;
    
    protected float xInput;
    protected float yInput = 0f;

    protected Rigidbody2D rb;
    protected Animator anim;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.Anim.SetBool(animBoolName, true);
        rb = player.Rb;
        anim = player.Anim;
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (rb.velocity.y < 0) 
        {
            stateMachine.ChangeState(player.FallState);
        }
    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }
}
