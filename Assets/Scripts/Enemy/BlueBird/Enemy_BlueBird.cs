using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_BlueBird : Enemy
{
    [Header("Move Details")]
    public float returnSpeed = .8f;
    public float followingSpeed = 1f;
    public float patrolSpeed = .5f;
    public float returnDistance = 4f;
    public float idleTime = 1f;
    public Transform[] patrolPoints;
    public int destinationPointIndex = 0;

    [Header("State Info")]
    public bool playerDetect = false;
    public bool isReturning = false;

    public Transform player;

    public float defaultBlueBirdYPos;

    #region States
    public BlueBirdPatrolState PatrolState { get; private set; }
    public BlueBirdIdleState IdleState { get; private set; }
    public BlueBirdFollowState FollowState { get; private set; }
    public BlueBirdReturnState ReturnState { get; private set; }
    public BlueBirdDeadState DeadState { get; private set; }
    #endregion

    protected override void Start()
    {
        base.Start();
        
        Rb.gravityScale = 0;
        enemyLayer = LayerMask.GetMask("FlyingEnemy");

        PatrolState = new BlueBirdPatrolState(this, StateMachine, "Move", this);
        IdleState = new BlueBirdIdleState(this, StateMachine, "Move", this);
        FollowState = new BlueBirdFollowState(this, StateMachine, "Move", this);
        ReturnState = new BlueBirdReturnState(this, StateMachine, "Move", this);
        DeadState = new BlueBirdDeadState(this, StateMachine, "Dead", this);

        defaultBlueBirdYPos = transform.position.y;

        StateMachine.InitializeState(PatrolState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject, 3f);
        StateMachine.ChangeState(DeadState);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.LayerCheck(_layer: enemyLayer))
            {
                Die();
            }
            else
            {
                SetVelocity(0, 0);
                player.Die();
            }
        }
    }

    public void FlyFlipCheck(Transform _target)
    {
        if (transform.position.x < _target.position.x)
        {
            if (FacingDir == -1)
            {
                Flip();
            }
        }
        else
        {
            if (FacingDir == 1)
            {
                Flip();
            }
        }
    }
}
