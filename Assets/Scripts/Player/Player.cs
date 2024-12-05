using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Parts")]
    [SerializeField] GameObject groundedCheck;
    [SerializeField] GameObject helicopter;
    public Slider helicopterSlider;
    [SerializeField] float groundedRadius = 0.2f;
    [SerializeField] float flashGroundYOffset = .2f;
    public GameObject gameOverMenu;

    [Header("Move Info")]
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 30f;
    public float flySpeed = 15f;
    public float flyTime = 5f;
    public float xBoundary = 3.1f;
    public int maxFlashCount = 3;
    public int flashCount = 3;

    public float flashChargingTime = 5f;

    public float gameOverAppearTime = 2f;

    LayerMask groundLayer;
    LayerMask trapLayer;

    public bool flashTrigger = false;
    public bool animationFinished = false;

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerDoubleJumpState DoubleJumpState { get; private set; }
    public PlayerFlyState FlyState { get; private set; }
    public PlayerFlashState FlashState { get; private set; }
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public CapsuleCollider2D Collider { get; private set; }
    public SpriteRenderer Sr { get; private set; }
    public TrailRenderer Tr { get; private set; }
    #endregion

    public int FacingDir { get; private set; } = 1;
    public bool IsFlying { get; set; } = false;
    public bool IsFlashing { get; set; } = false;

    void Awake()
    {
        StateMachine = new PlayerStateMachine();
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        FallState = new PlayerFallState(this, StateMachine, "Fall");
        DeadState = new PlayerDeadState(this, StateMachine, "Dead");
        DoubleJumpState = new PlayerDoubleJumpState(this, StateMachine, "Double Jump");
        FlyState = new PlayerFlyState(this, StateMachine, "Fly");
        FlashState = new PlayerFlashState(this, StateMachine, "Flash");

        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();

        Anim = GetComponentInChildren<Animator>();
        Sr = GetComponentInChildren<SpriteRenderer>();
        Tr = GetComponentInChildren<TrailRenderer>();
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

        flashCount = maxFlashCount;
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



    public bool LayerCheck(LayerMask _layer)
    {
        if (!Collider.enabled)
            return false;

        RaycastHit2D hit = Physics2D.CircleCast(groundedCheck.transform.position, groundedRadius, Vector2.down, 0, _layer);

        if (_layer == groundLayer)
        {
            if (hit.collider != null)
            {
                FallingGround fallingGround = hit.collider.GetComponent<FallingGround>();
                if (fallingGround != null)
                {
                    fallingGround.Fall();
                }
                return true; // �浹�� �ִ� ��� true ��ȯ
            }
            return false; // �浹�� ���� ��� false ��ȯ
        }
        else
        {
            return hit.collider != null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundedCheck.transform.position, groundedRadius);
    }

    #region Player Actions
    public void Flip()
    {
        FacingDir = -FacingDir;

        transform.Rotate(0, 180, 0);
        helicopterSlider.transform.Rotate(0, 180, 0);
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
    public void Jump()
    {
        StateMachine.ChangeState(JumpState);
    }

    public void Flash()
    {
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        GameObject[] higherGrounds = grounds
            .Where(ground => ground.transform.position.y > transform.position.y)
            .OrderBy(ground => ground.transform.position.y)
            .ToArray();

        switch (higherGrounds.Length)
        {
            case 0:
                return;
            case 1:
                transform.position = higherGrounds[0].transform.position + new Vector3(0, flashGroundYOffset, 0);
                return;
            default:
                transform.position = higherGrounds[1].transform.position + new Vector3(0, flashGroundYOffset, 0);
                return;
        }
    }
    #endregion

    public void HelicopterActivate(bool _flying)
    {
        helicopter.SetActive(_flying);
    }
}