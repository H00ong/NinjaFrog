using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimationTrigger : MonoBehaviour
{
    Enemy_Tree tree;

    void Start()
    {
        tree = GetComponentInParent<Enemy_Tree>();
    }

    void Shoot() 
    {
        StartCoroutine(Bullet());
    }

    IEnumerator Bullet() 
    {
        tree.ShootBullet();
        yield return new WaitForSeconds(tree.attackDelay);
        tree.ShootBullet();
        yield return new WaitForSeconds(tree.attackDelay);
        tree.ShootBullet();
    }

    void AnimationTrigger() 
    {
        tree.animationTrigger = true;
    }
}
