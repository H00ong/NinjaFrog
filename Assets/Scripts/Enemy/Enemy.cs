using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Move Info")]
    [SerializeField] protected float moveSpeed = 3f;

    [SerializeField] float groundCheckDistance = .5f;

    [SerializeField] protected Transform groundCheck;

    protected LayerMask groundLayer;
    protected LayerMask enemyLayer;

    protected Animator Anim;
    protected Rigidbody2D Rb;
    protected Collider2D Collider;

    protected bool isLive = true;

    protected int FacingDir { get; private set; }

    protected virtual void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        enemyLayer = LayerMask.GetMask("Enemy");
        FacingDir = GetComponentInChildren<SpriteRenderer>().flipX ? 1 : -1;

        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        if (!isLive) return;

        if (!GroundCheck())
        {
            SetVelocity(0);
            Flip();
        }
        else
        {
            SetVelocity(moveSpeed);
        }
    }

    protected virtual void Flip()
    {
        FacingDir = -FacingDir;
        transform.Rotate(0, 180, 0);
    }

    protected void SetVelocity(float _xSpeed, float _ySpeed = 0f) 
    {
        Rb.velocity = new Vector2(FacingDir * _xSpeed, _ySpeed);
    }

    protected virtual bool GroundCheck()
    {
        return Physics2D.Linecast(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance), groundLayer);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance));
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player.LayerCheck(_layer: enemyLayer))
            {
                Die();
            }
            else 
            {
                player.Die();
            }
        }
    }

    protected virtual void Die() 
    {
        Anim.SetBool("Die", true);
        
        isLive = false;
        Collider.enabled = false;

        Rb.gravityScale = 1f;
        SetVelocity(0, 5);

        Destroy(gameObject, 3f);
    }
}
