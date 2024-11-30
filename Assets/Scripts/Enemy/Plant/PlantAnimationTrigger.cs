using System.Collections;
using UnityEngine;

public class PlantAnimationTrigger : MonoBehaviour
{
    Enemy_Plant plant;

    void Start()
    {
        plant = GetComponentInParent<Enemy_Plant>();
    }

    void Shoot()
    {
        StartCoroutine(Bullet());
    }

    IEnumerator Bullet()
    {
        plant.ShootBullet();
        yield return new WaitForSeconds(plant.attackDelay);
        plant.ShootBullet();
        yield return new WaitForSeconds(plant.attackDelay);
        plant.ShootBullet();
    }

    void AnimationTrigger()
    {
        plant.animationTrigger = true;
    }
}
