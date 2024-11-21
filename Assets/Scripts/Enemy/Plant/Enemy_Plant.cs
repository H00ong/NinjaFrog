using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plant : Enemy
{
    [Header("Move Details")]
    public float idleTime = 2f;

    [Header("Attack Info")]
    public float attackDelay = .15f;
    public float bulletSpeed = 3f;
    public float bulletLifeTime = 4f;
    public GameObject bullet;
    public Vector2 shootingDir;
    public Transform shootingPos;


    [Header("State Info")]
    public bool playerDetect = false;
    public bool isShooting = false;

    public Transform player;
    public bool animationTrigger = false;
    #region States
    public PlantIdleState IdleState { get; private set; }
    public PlantDeadState DeadState { get; private set; }
    public PlantAttackState AttackState { get; private set; }
    #endregion

    protected override void Start()
    {
        base.Start();

        IdleState = new PlantIdleState(this, StateMachine, "Idle", this);
        DeadState = new PlantDeadState(this, StateMachine, "Dead", this);
        AttackState = new PlantAttackState(this, StateMachine, "Attack", this);

        StateMachine.InitializeState(IdleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

    public override bool FlipCheck()
    {
        if (playerDetect) 
        {
            if (player != null) 
            {
                if (transform.position.x < player.position.x) 
                {
                    if (FacingDir == -1)
                    {
                        return true;
                    }
                }
                else 
                {
                    if (FacingDir == 1) 
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, shootingPos.position, Quaternion.identity);
        
        if (shootingDir != Vector2.zero)
        {
            newBullet.GetComponent<Rigidbody2D>().velocity = shootingDir * bulletSpeed;
            newBullet.transform.right = shootingDir;
        }
        else 
        {
            newBullet.transform.localRotation = transform.localRotation;
            newBullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
        }

        Destroy(newBullet, bulletLifeTime);
    }
}
