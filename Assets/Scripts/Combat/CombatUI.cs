using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1HP;
    [SerializeField] private TextMeshProUGUI player2HP;

    [SerializeField] private TextMeshProUGUI player1Damage;
    [SerializeField] private TextMeshProUGUI player2Damage;

    [SerializeField] private TextMeshProUGUI player1Effects;
    [SerializeField] private TextMeshProUGUI player2Effects;

    public UnityEvent<int, int, bool> displayHP;
    public UnityEvent<int, bool> displayDamage;
    public UnityEvent<LingeringSkill[], bool> displayEffects;

    public void Start()
    {
        displayHP.AddListener(DisplayHP);
        displayDamage.AddListener(DisplayDamage);
        displayEffects.AddListener(DisplayEffects);
    }

    private void DisplayHP(int currentPlayerHP, int maxPlayerHP, bool player)
    {
        TextMeshProUGUI playerHP;
        if (!player) { playerHP = player1HP; }
        else { playerHP = player2HP; }

        playerHP.text = $"HP: {currentPlayerHP}/{maxPlayerHP}";
    }

    private void DisplayDamage(int damage, bool player)
    {
        TextMeshProUGUI playerDamage;
        if (!player) { playerDamage = player1Damage; }
        else { playerDamage = player2Damage; }

        playerDamage.text += $" -{damage}";
    }

    private void DisplayEffects(LingeringSkill[] skills, bool player)
    {
        TextMeshProUGUI playerEffects;
        if (!player) { playerEffects = player1Effects; }
        else { playerEffects = player2Effects; }

        string text = "";
        foreach (LingeringSkill skill in skills)
        {
            if (skill != null)
            {
                text += SkillDescriptions.skillDescriptions[skill.skillId].effect_name;
                text += $" {skill.remainingTicks}/{skill.totalTicks} | ";
            }
        }
        playerEffects.text = text;
    }
}