using System.Collections;
using System.Collections.Generic;
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
