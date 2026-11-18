using System;
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

    public abstract PlayerStats playerStats { get; }
    public SkillType type;

    public Skill selectedSkill = null;

    public LingeringSkill[] lingeringSkills = new LingeringSkill[3];

    public void Init()
    {
        InitBaseStats();
        InitBaselineStats();
        OnAwake();
    }

    public abstract void InitBaseStats();

    protected virtual void SetType()
    {
        System.Type[] skills = { playerStats.skill1, playerStats.skill2, playerStats.skill3, playerStats.skill4 };
        for (int i = 0; i < 4; i++)
        {
            Skill skill1 = (Skill)Activator.CreateInstance(skills[i]);
            for (int j = i + 1; j < 4; j++)
            {
                Skill skill2 = (Skill)Activator.CreateInstance(skills[j]);
                if (skill1.skillType == skill2.skillType)
                {
                    type = skill1.skillType;
                    return;
                }
            }
        }
    }

    private void InitBaselineStats()
    {
        SetType();

        switch (type)
        {
            case SkillType.Aggressive: 
                _obtainedAtk += 0.5f; 
                _obtainedHP -= 0.5f;
                break;
            case SkillType.Intimidating:
                _obtainedHP += 0.5f;
                _obtainedDef -= 0.5f;
                break;
            case SkillType.Conniving:
                _obtainedDef += 0.5f;
                _obtainedAtk -= 0.5f;
                break;
            default: break;
        }

        _baselineAtk = (int)(_baseAtk * (1 + _obtainedAtk));
        _baselineHP = (int)(_baseHP * (1 + _obtainedHP));
        _baselineDef = (int)(_baseDef * (1 + _obtainedDef));

        _maxHP = _baselineHP;
        _currentHP = _maxHP;
    }

    public virtual void OnAwake() { }

    public int Atk()
    {
        return (int)(_baselineAtk * (1 + _bonusAtk));
    }

    public int Def()
    {
        return (int)(_baselineDef * (1 + _bonusDef));
    }

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

    public int CurrentHP() { return _currentHP; }

    public int MaxHP() { return _maxHP; }

    public float RemainingHP()
    {
        return (float)_currentHP / (float)_maxHP;
    }

    public virtual int Heal(float heal)
    {
        int healValue = (int)(heal * _maxHP);
        _currentHP += healValue;
        //Debug.Log($"healed for {heal*100}%");
        _currentHP = Mathf.Min(_currentHP, _maxHP);
        return healValue;
    }

    public virtual void Heal(int heal)
    {
        _currentHP += heal;
        //Debug.Log($"healed for {heal}");
        _currentHP = Mathf.Min(_currentHP, _maxHP);
    }

    public int CalculateAtkSkillDamage(float motionValue)
    {
        return (int)(_baselineAtk * (1 + _bonusAtk) * motionValue);
    }

    public int CalculateDefSkillDamage(float motionValue)
    {
        return (int)(_baselineDef * (1 + _bonusDef) * motionValue);
    }

    public int CalculateMaxHPSkillDamage(float motionValue)
    {
        return (int)(_maxHP * motionValue);
    }

    public virtual int TakeSkillDamage(int attackDamage)
    {
        float defMultiplier = _baselineDef * (1 + _bonusDef);
        int damage = (int)(attackDamage * (1 - defMultiplier / (defMultiplier + 250)));
        _currentHP -= damage;
        //Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            //Debug.Log("Wolf dead");
        }

        return damage;
    }

    public virtual void TakeDirectDamage(int attackDamage)
    {
        _currentHP -= attackDamage;
        //Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP < 0)
        {
            _currentHP = 0;
            //Debug.Log("Wolf dead");
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
