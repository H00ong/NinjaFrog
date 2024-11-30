using UnityEngine;

public class TramplineAnimationTrigger : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    void DoubleJumpTrigger()
    {
        player.DoubleJump();
    }
}
