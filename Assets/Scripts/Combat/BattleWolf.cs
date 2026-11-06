using UnityEngine;

public class BattleWolf : MonoBehaviour
{
    [SerializeField] protected BattleManager battleManager;

    private int _baseAttack = 100;
    private float _obtainedAttack = 0.5f;
    private float _bonusAttack = 0f;
    private int _baselineAttack;

    private float _baseDefence = 0.1f;
    private float _obtainedDefence = 0f;
    private float _bonusDefence = 0f;
    private float _baselineDefence;

    private int _baseHP = 1000;
    private float _obtainedHP = 0f;
    private float _bonusHP = 0f;
    private int _baselineHP;

    private int _maxHP;
    private int _currentHP;

    public Skill selectedSkill;

    public LingeringSkill[] lingeringSkills = new LingeringSkill[3];

    public void Awake()
    {
        InitStats();
        OnAwake();
    }

    private void InitStats()
    {
        _baselineAttack = (int)(_baseAttack * (1 + _obtainedAttack));
        _baselineHP = (int)(_baseHP * (1 + _obtainedHP));
        _baselineDefence = _baseDefence + _obtainedDefence;

        _maxHP = _baselineHP;
        _currentHP = _maxHP;
    }

    public virtual void OnAwake() { }

    public int CalculateSkillDamage(float motionValue)
    {
        return (int)(_baselineAttack * (1 + _bonusAttack) * motionValue);
    }

    public void TakeDamage(int attackDamage)
    {
        _currentHP -= (int)(attackDamage * (1 - (_baselineDefence + _bonusDefence)));
        Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP < 0)
        {
            _currentHP = 0;
            Debug.Log("Wolf dead");
        }
    }

    public virtual void SelectSkill()
    {
        selectedSkill = new Scratch();
        battleManager.PlayerSelectedSkill(this);
    }

    public void SetLingeringSkill(LingeringSkill effect)
    {
        for (int i = 0; i < lingeringSkills.Length; i++)
        {  
            if (lingeringSkills[i] == null) { lingeringSkills[i] = effect; return; }
        }

        int firstToExpire = 0;
        int minRemainingDuration = int.MaxValue;
        
        for (int i = 0; i < lingeringSkills.Length; i++)
        {
            if (lingeringSkills[i].remainingTicks < minRemainingDuration) 
            { 
                firstToExpire = i;
                minRemainingDuration = lingeringSkills[i].remainingTicks;
            }
        }
        lingeringSkills[firstToExpire] = effect;
    }
}
