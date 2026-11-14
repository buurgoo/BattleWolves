using UnityEngine;
using UnityEngine.InputSystem;

public class WolfController : MonoBehaviour
{
    [SerializeField] private WolfState currentState = WolfState.Idle;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-5f, -2.595012f, 0f);
    private BaseWolfState activeState;

    public InputAction moveAction;
    public Rigidbody2D rb { get; private set; }

    private SpriteRenderer sprite;
    private int faceDirection = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.position = spawnPosition;
        ChangeState(WolfState.Idle);
    }

    public void ChangeState(WolfState newState)
    {
        activeState?.EndState();
        currentState = newState;

        activeState = newState switch 
        {
            WolfState.Idle     => new WolfIdleState(this),
            WolfState.Walk     => new WolfWalkState(this),
            // WolfState.Eat      => new WolfEatState(this),
            // WolfState.Sleep    => new WolfSleepState(this),
            // WolfState.BathTime => new WolfBathTimeState(this),
            _                  => new WolfIdleState(this)
        };

        activeState.EnterState();
    }

    private void Update()
    {
        float move = moveAction.ReadValue<float>();

        if (Mathf.Abs(move) > 0.01f)
        {
            faceDirection = move < 0 ? -1 : 1;
            ChangeState(WolfState.Walk);
        }
        else ChangeState(WolfState.Idle);

        activeState?.UpdateState();
    }

    private void FixedUpdate()
    {
        activeState?.FixedUpdateState();
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }
}