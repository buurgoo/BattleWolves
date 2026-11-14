using UnityEngine;

public class BattleWolf : MonoBehaviour
{
    [SerializeField] protected BattleManager battleManager;

    private int _baseAttack = 100;
    private float _bonusAttack = 0.5f;
    private int _baselineAttack;

    private int _baseHP = 1000;
    private float _bonusHP = 0f;
    private int _baselineHP;

    private int _maxHP;
    private int _currentHP;

    public Skill selectedSkill;

    public void Start()
    {
        InitStats();
        OnStart();
    }

    private void InitStats()
    {
        _baselineAttack = (int)(_baseAttack * (1 + _bonusAttack));
        _baselineHP = (int)(_baseHP * (1 + _bonusHP));

        _maxHP = _baselineHP;
        _currentHP = _maxHP;
    }

    public virtual void OnStart() { }

    public int GetBaselineAttack()
    {
        return _baselineAttack;
    }

    public int CalculateSkillDamage(float motionValue)
    {
        return (int)(_baselineAttack  * motionValue);
    }

    public int GetMaxHP()
    {
        return _maxHP;
    }

    public int GetCurrentHP()
    {
        return _currentHP;
    }

    public void TakeDamage(int attackDamage)
    {
        _currentHP -= attackDamage;
        Debug.Log($"Wolf HP: {_currentHP}/{_maxHP}");

        if (_currentHP < 0) 
        { 
            _currentHP = 0;
            Debug.Log("Wolf dead");
        }
    }

    public virtual void SelectSkill()
    {
        selectedSkill = new BasicAttack();
        battleManager.PlayerSelectedSkill(this);
    }
}
