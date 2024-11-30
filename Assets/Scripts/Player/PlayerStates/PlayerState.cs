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
        anim = player.Anim;
        rb = player.Rb;
        anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        if (player.flashCount > 0 && Input.GetKeyDown(KeyCode.Space) && !player.IsFlying && !player.IsFlashing)
        {
            stateMachine.ChangeState(player.FlashState);
            return;
        }

        if (player.LayerCheck(LayerMask.GetMask("Ground")))
        {
            player.Jump();
            return;
        }

        xInput = Input.GetAxisRaw("Horizontal");

        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.FallState);
            return;
        }

    }

    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }
}
