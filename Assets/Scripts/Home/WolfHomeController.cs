using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class WolfHomeController : MonoBehaviour
{
    [SerializeField] private WolfState currentState = WolfState.Idle;
    [SerializeField] private Vector3 spawnPosition = new Vector3(-5f, -2.595012f, 0f);
    private BaseWolfState activeState;

    public InputAction moveToPositionAction;
    public InputAction callAction;
    private float targetPos;

    private Camera cam;

    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }

    private SpriteRenderer sprite;
    private int faceDirection = 1;

    [SerializeField] private int level = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int requiredXP = 340125;

    [Header("Wolf Stats")]
    [SerializeField, Range(0, 100)] private float hp = 100f;
    [SerializeField, Range(0, 100)] private float sleepy = 0f;
    [SerializeField, Range(0, 100)] private float hungry = 0f;
    [SerializeField, Range(0, 100)] private float stinky = 0f;
    [SerializeField, Range(0, 100)] private float bloodthirst = 0f;

    private float statsTimer = 0f;

    public int Level => level;
    public int CurrentXP => currentXP;
    public int RequiredXP => requiredXP;

    public float HP => hp;
    public float Sleepy => sleepy;
    public float Hungry => hungry;
    public float Stinky => stinky;
    public float Bloodthirst => bloodthirst;

    [SerializeField] private FeedingManager feedingManager;
    public FeedingManager FeedingManager => feedingManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        sleepy = WolfSessionData.sleepy;
        hungry = WolfSessionData.hungry;
        stinky = WolfSessionData.stinky;
        bloodthirst = WolfSessionData.bloodthirst;

        cam = Camera.main;
        targetPos = spawnPosition.x;
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
            WolfState.Run      => new WolfRunState(this),
            WolfState.Eat      => new WolfEatState(this),
            WolfState.Sleep    => new WolfSleepState(this),
            WolfState.BathTime => new WolfBathTimeState(this),
            _                  => new WolfIdleState(this)
        };

        activeState.EnterState();
    }

    private void Update()
    {
        if (callAction.triggered)
        {
            float moveTo = moveToPositionAction.ReadValue<float>();
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(moveTo, 0, cam.nearClipPlane));
            CallToTarget(point.x);
        }
        else
        {
            if (currentState == WolfState.Idle)
            {
                if (UnityEngine.Random.Range(0f, 1f) < 0.0005f)
                {
                    targetPos = rb.position.x + UnityEngine.Random.Range(-3f, 3f);
                }
            }
            if (currentState != WolfState.Eat &&
                currentState != WolfState.Sleep &&
                currentState != WolfState.BathTime)
            {
                if (Mathf.Abs(GetMove()) > 0.01f)
                {
                    if (currentState == WolfState.Run) { ChangeState(WolfState.Run); }
                    else { ChangeState(WolfState.Walk); }
                }
                else ChangeState(WolfState.Idle);
            }
        }

        activeState?.UpdateState();
        UpdateStats();
    }

    public void CallToTarget(float position)
    {
        targetPos = position;
        ChangeState(WolfState.Run);
    }

    public float GetMove()
    {
        float posDiff = targetPos - rb.position.x;
        if (Math.Abs(posDiff) > 0.1f)
        {
            float move = Math.Sign(posDiff);
            faceDirection = move < 0 ? -1 : 1;
            return move;
        }
        return 0;
    }

    private void UpdateStats()
    {
        statsTimer += Time.deltaTime;

        if (statsTimer >= 10f)
        {
            statsTimer -= 10f;

            sleepy = Mathf.Min(sleepy + 1f, 100f);
            hungry = Mathf.Min(hungry + 3f, 100f);
            stinky = Mathf.Min(stinky + 5f, 100f);
            bloodthirst = Mathf.Min(bloodthirst + 5f, 100f);
            
            WolfSessionData.SaveNeeds(sleepy, hungry, stinky, bloodthirst);
            
            //add check for max hp
            System.WolfSessionData.SaveHP(HP);
        }
    }

    public void ReduceHunger(float amount)
    {
        hungry = Mathf.Max(hungry - amount, 0f);
        WolfSessionData.SaveNeeds(sleepy, hungry, stinky, bloodthirst);
    }

        public void ReduceSleepy(float amount)
    {
        sleepy = Mathf.Max(sleepy - amount, 0f);
        WolfSessionData.SaveNeeds(sleepy, hungry, stinky, bloodthirst);
    }

    public void ReduceStinky(float amount)
    {
        stinky = Mathf.Max(stinky - amount, 0f);
        WolfSessionData.SaveNeeds(sleepy, hungry, stinky, bloodthirst);
    }

    public void Healing(float amount)
    {
        hp = Mathf.Clamp(hp + amount, 0f, 100f);
        WolfSessionData.SaveHP(hp);
    }

    public void OnEatButtonClicked()
    {
        Debug.Log("Home: Eat button clicked");
        ChangeState(WolfState.Eat);
    }

    public void OnSleepButtonClicked()
    {
        Debug.Log("Home: Sleep button clicked");
        if (currentState == WolfState.Sleep) ChangeState(WolfState.Idle);
        else ChangeState(WolfState.Sleep);
    }

    public void OnBathButtonClicked()
    {
        Debug.Log("Home: Bath button clicked");
        ChangeState(WolfState.BathTime);
    }

    public void OnActionAnimationFinished()
    {
        if (currentState == WolfState.Eat)
            ChangeState(WolfState.Idle);
    }

    private void FixedUpdate()
    {
        activeState?.FixedUpdateState();
    }
    private void OnEnable()
    {
        callAction.Enable();
        moveToPositionAction.Enable();
    }

    private void OnDisable()
    {
        callAction.Disable();
        moveToPositionAction.Disable();
    }

    private void OnDestroy()
    {
        WolfSessionData.SaveNeeds(sleepy, hungry, stinky, bloodthirst);
    }
}