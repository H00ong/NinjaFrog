using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject groundedCheck;
    [SerializeField] float groundedRadius = 0.2f;
    LayerMask groundLayer;

    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 30f;

    public float xBoundary = 3.1f;

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerDoubleJumpState DoubleJumpState { get; private set; }
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public CapsuleCollider2D Collider { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    #endregion

    public int FacingDir { get; private set; } = 1;

    void Awake()
    {
        StateMachine = new PlayerStateMachine();
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        FallState = new PlayerFallState(this, StateMachine, "Fall");
        DeadState = new PlayerDeadState(this, StateMachine, "Dead");
        DoubleJumpState = new PlayerDoubleJumpState(this, StateMachine, "Double Jump");

        Rb           = GetComponent<Rigidbody2D>();
        Collider     = GetComponent<CapsuleCollider2D>();

        Anim           = GetComponentInChildren<Animator>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
          StateMachine.InitializeState(JumpState);
          groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        StateMachine.CurrentState.Update();
    }

    public void SetVelocity(float _xInput, float _yInput)
    {
        Rb.velocity = new Vector2(_xInput, _yInput);
        FlipControl(_xInput);
    }

    public void SetZeroVelocity() => SetVelocity(0, Rb.velocity.y);

    public void FlipControl(float _xInput)
    {
        if (FacingDir == 1 && _xInput < 0)
        {
            Flip();
        }
        else if (FacingDir == -1 && _xInput > 0) 
        {
            Flip();
        }   
    }

    public void Flip() 
    {
        FacingDir = -FacingDir;

        transform.Rotate(0, 180, 0);
    }

    public bool JumpCheck() 
    {
        if(!Collider.enabled)
            return false;

        return Physics2D.CircleCast(groundedCheck.transform.position, groundedRadius, Vector2.down, 0, groundLayer);   
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundedCheck.transform.position, groundedRadius);
    }

    public void Die() 
    {
        StateMachine.ChangeState(DeadState);
    }

    public void DoubleJump() 
    {
        StateMachine.ChangeState(DoubleJumpState);
    }
}
