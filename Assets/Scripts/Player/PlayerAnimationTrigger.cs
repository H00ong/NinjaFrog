using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    public void FlashTrigger()
    {
        player.flashTrigger = true;
    }

    public void AnimationFinishTrigger()
    {
        player.animationFinished = true;
    }
}
