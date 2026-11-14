using UnityEngine;
using UnityEngine.InputSystem;

public class WolfHomeController : MonoBehaviour
{
    [SerializeField] private WolfState currentState = WolfState.Idle;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-5f, -2.595012f, 0f);
    private BaseWolfState activeState;

    public InputAction moveAction;
    public Rigidbody2D rb { get; private set; }

    private SpriteRenderer sprite;
    private int faceDirection = 1;

    [Header("Wolf Stats")]
    [SerializeField, Range(0, 100)] private float hp = 100f;
    [SerializeField, Range(0, 100)] private float sleepy = 0f;
    [SerializeField, Range(0, 100)] private float hungry = 0f;
    [SerializeField, Range(0, 100)] private float stinky = 0f;
    [SerializeField, Range(0, 100)] private float bloodthirst = 0f;

    private float statsTimer = 0f;

    public float HP => hp;
    public float Sleepy => sleepy;
    public float Hungry => hungry;
    public float Stinky => stinky;
    public float Bloodthirst => bloodthirst;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // sprite = GetComponent<SpriteRenderer>();
        transform.position = spawnPosition;
        ChangeState(WolfState.Idle);
    }

    public void ChangeState(WolfState newState)
    {
        if (currentState == newState && activeState != null) return;

        activeState?.EndState();
        currentState = newState;

        activeState = newState switch 
        {
            WolfState.Idle     => new WolfIdleState(this),
            WolfState.Walk     => new WolfWalkState(this),
            WolfState.Eat      => new WolfEatState(this),
            WolfState.Sleep    => new WolfSleepState(this),
            WolfState.BathTime => new WolfBathTimeState(this),
            _                  => new WolfIdleState(this)
        };

        activeState.EnterState();
    }

    private void Update()
    {
        float move = moveAction.ReadValue<float>();

        if (currentState != WolfState.Eat &&
            currentState != WolfState.Sleep &&
            currentState != WolfState.BathTime)
        {
            if (Mathf.Abs(move) > 0.01f)
            {
                faceDirection = move < 0 ? -1 : 1;
                ChangeState(WolfState.Walk);
            }
            else ChangeState(WolfState.Idle);
        }

        activeState?.UpdateState();
        if (currentState == WolfState.Eat ||
            currentState == WolfState.Sleep ||
            currentState == WolfState.BathTime) 
                ChangeState(WolfState.Idle);
        
        UpdateStats();
    }

    private void UpdateStats()
    {
        statsTimer += Time.deltaTime;

        if (statsTimer >= 10f)
        {
            statsTimer -= 10f;

            sleepy = Mathf.Min(sleepy + 5f, 100f);
            hungry = Mathf.Min(hungry + 5f, 100f);
            stinky = Mathf.Min(stinky + 5f, 100f);
            bloodthirst = Mathf.Min(bloodthirst + 5f, 100f);
        }
    }

    public void ReduceHunger(float amount)
    {
        hungry = Mathf.Max(hungry - amount, 0f);
    }

        public void ReduceSleepy(float amount)
    {
        sleepy = Mathf.Max(sleepy - amount, 0f);
    }

    public void ReduceStinky(float amount)
    {
        stinky = Mathf.Max(stinky - amount, 0f);
    }

    public void OnEatButtonClicked()
    {
        Debug.Log("Home: Eat button clicked");
        ChangeState(WolfState.Eat);
    }

    public void OnSleepButtonClicked()
    {
        Debug.Log("Home: Sleep button clicked");
        ChangeState(WolfState.Sleep);
    }

    public void OnBathButtonClicked()
    {
        Debug.Log("Home: Bath button clicked");
        ChangeState(WolfState.BathTime);
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