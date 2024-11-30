using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) :
        base(_player, _stateMachine, _animBoolName)
    { }

    float timer = 0;

    public override void Enter()
    {
        base.Enter();

        player.Collider.enabled = false;
        rb.gravityScale = 0f;
        timer = player.gameOverAppearTime;

        if (player.gameOverMenu == null)
        {
            player.gameOverMenu = GameObject.Find("Ui_GameOverMenu");
        }
    }

    public override void Update()
    {
        player.SetVelocity(0, 0);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            player.gameOverMenu?.SetActive(true);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
