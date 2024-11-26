using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Parts")]
    [SerializeField] GameObject groundedCheck;
    [SerializeField] GameObject helicopter;
    [SerializeField] float groundedRadius = 0.2f;

    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 30f;
    public float flySpeed = 15f;
    public float flyTime = 5f;
    public float xBoundary = 3.1f;

    public float gameOverAppearTime = 2f;

    LayerMask groundLayer;
    LayerMask trapLayer;

    public GameObject gameOverMenu;


    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerDoubleJumpState DoubleJumpState { get; private set; }
    public PlayerFlyState FlyState { get; private set; }
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public CapsuleCollider2D Collider { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    #endregion

    public int FacingDir { get; private set; } = 1;
    public bool IsFlying { get; set; } = false;

    void Awake()
    {
        StateMachine = new PlayerStateMachine();
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        FallState = new PlayerFallState(this, StateMachine, "Fall");
        DeadState = new PlayerDeadState(this, StateMachine, "Dead");
        DoubleJumpState = new PlayerDoubleJumpState(this, StateMachine, "Double Jump");
        FlyState = new PlayerFlyState(this, StateMachine, "Fly");

        Rb           = GetComponent<Rigidbody2D>();
        Collider     = GetComponent<CapsuleCollider2D>();

        Anim           = GetComponentInChildren<Animator>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1f;
        }

        StateMachine.InitializeState(JumpState);

        groundLayer = LayerMask.GetMask("Ground");
        trapLayer = LayerMask.GetMask("Trap");
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
        if (FacingDir == 1 && (Mathf.Abs(_xInput) > Constants.threshold && _xInput < 0))
        {
            Flip();
        }
        else if (FacingDir == -1 && (Mathf.Abs(_xInput) > Constants.threshold && _xInput > 0)) 
        {
            Flip();
        }   
    }

    public void Flip() 
    {
        FacingDir = -FacingDir;

        transform.Rotate(0, 180, 0);
    }

    public bool LayerCheck(LayerMask _layer)
    {
        if (!Collider.enabled)
            return false;

        if (_layer == groundLayer)
        {
            RaycastHit2D hit = Physics2D.CircleCast(groundedCheck.transform.position, groundedRadius, Vector2.down, 0, _layer);

            if (hit.collider != null)
            {
                FallingGround fallingGround = hit.collider.GetComponent<FallingGround>();
                if (fallingGround != null)
                {
                    fallingGround.Fall();
                }
                return true; // 충돌이 있는 경우 true 반환
            }
            return false; // 충돌이 없는 경우 false 반환
        }
        else
        {
            return Physics2D.CircleCast(groundedCheck.transform.position, groundedRadius, Vector2.down, 0, _layer);
        }
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

    public void Fly() 
    {
        StateMachine.ChangeState(FlyState);
    }

    public void HelicopterActive(bool _flying)
    {
        helicopter.SetActive(_flying);
    }

    public void Jump() 
    {
        StateMachine.ChangeState(JumpState);
    }
}