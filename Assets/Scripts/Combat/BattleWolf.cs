using UnityEngine;

public abstract class BattleWolf : MonoBehaviour
{
    [SerializeField] protected BattleManager battleManager;

    protected int _baseAtk = 0;
    protected float _obtainedAtk = 0f;
    private float _bonusAtk = 0f;
    private int _baselineAtk;

    protected int _baseDef = 0;
    protected float _obtainedDef = 0f;
    private float _bonusDef = 0f;
    private float _baselineDef;

    protected int _baseHP = 0;
    protected float _obtainedHP = 0f;
    private float _bonusHP = 0f;
    private int _baselineHP;

    private int _maxHP;
    private int _currentHP;
    
    
    //NEW CHANGES BEWARE
    protected float _bloodthirstBonus = 0f;

    public abstract PlayerStats playerStats { get; }

    public Skill selectedSkill = null;

    public LingeringSkill[] lingeringSkills = new LingeringSkill[3];

    public void Init()
    {
        InitBaseStats();
        InitBaselineStats();
        OnAwake();
    }

    public abstract void InitBaseStats();

    private void InitBaselineStats()
    {
        _baselineAtk = (int)(_baseAtk * (1 + _obtainedAtk));
        _baselineHP = (int)(_baseHP * (1 + _obtainedHP));
        _baselineDef = (int)(_baseDef * (1 + _obtainedDef));

        _maxHP = _baselineHP;
        _currentHP = _maxHP;
    }

    public virtual void OnAwake() { }

    public void ModifyAtk(float atk)
    {
        _bonusAtk += atk;
    }

    public void ModifyDef(float def)
    {
        _bonusDef += def;
    }

    public void ModifyHP(float HP, bool filled)
    {
        _bonusHP += HP;
        int extraHP = (int)(_baselineHP * _bonusHP);
        _maxHP += extraHP;
        if (filled)
        {
            _currentHP += extraHP;
        }
        _currentHP = Mathf.Min(_currentHP, _maxHP);
    }

    public int GetCurrentHP() { return _currentHP; }

    public int GetMaxHP() { return _maxHP; }

    public float GetRemainingHP()
    {
        return (float)_currentHP / (float)_maxHP;
    }

    public int CalculateSkillDamage(float motionValue)
    {
        return (int)(_baselineAtk * (1 + _bonusAtk) * (1 + _bloodthirstBonus) * motionValue);
    }

    public virtual int TakeSkillDamage(int attackDamage)
    {
        float defMultiplier = _baselineDef * (1 + _bonusDef);
        int damage = (int)(attackDamage * (1 - defMultiplier / (defMultiplier + 1000)));
        _currentHP -= damage;
        Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            Debug.Log("Wolf dead");
        }

        return damage;
    }

    public virtual void TakeDirectDamage(int attackDamage)
    {
        _currentHP -= attackDamage;
        Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP < 0)
        {
            _currentHP = 0;
            Debug.Log("Wolf dead");
        }
    }

    public abstract void SelectSkill();

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
