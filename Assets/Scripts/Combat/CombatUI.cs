using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1HP;
    [SerializeField] private TextMeshProUGUI player2HP;

    [SerializeField] private TextMeshProUGUI player1Damage;
    [SerializeField] private TextMeshProUGUI player2Damage;

    [SerializeField] private TextMeshProUGUI player1Effects;
    [SerializeField] private TextMeshProUGUI player2Effects;

    [SerializeField] private Button playerSkill1;
    [SerializeField] private Button playerSkill2;
    [SerializeField] private Button playerSkill3;
    [SerializeField] private Button playerSkill4;

    [SerializeField] private TextMeshProUGUI gameOver;

    public UnityEvent<int, int, bool> displayHP;
    public UnityEvent<int, bool> displayDamage;
    public UnityEvent<LingeringSkill[], bool> displayEffects;
    public UnityEvent<bool> displayGameOver;

    public void Start()
    {
        displayHP.AddListener(DisplayHP);
        displayDamage.AddListener(DisplayDamage);
        displayEffects.AddListener(DisplayEffects);
        displayGameOver.AddListener(DisplayGameOver);

        gameOver.gameObject.SetActive(false);
    }

    public void SetSkillButtonText(System.Type skillType1, System.Type skillType2, 
                                   System.Type skillType3, System.Type skillType4)
    {
        TextMeshProUGUI skill1text = playerSkill1.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI skill2text = playerSkill2.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI skill3text = playerSkill3.GetComponentInChildren<TextMeshProUGUI>();
        TextMeshProUGUI skill4text = playerSkill4.GetComponentInChildren<TextMeshProUGUI>();

        Skill skillInst1 = (Skill)Activator.CreateInstance(skillType1);
        Skill skillInst2 = (Skill)Activator.CreateInstance(skillType2);
        Skill skillInst3 = (Skill)Activator.CreateInstance(skillType3);
        Skill skillInst4 = (Skill)Activator.CreateInstance(skillType4);

        skill1text.text = SkillDescriptions.skillDescriptions[skillInst1.skillId].name;
        skill2text.text = SkillDescriptions.skillDescriptions[skillInst2.skillId].name;
        skill3text.text = SkillDescriptions.skillDescriptions[skillInst3.skillId].name;
        skill4text.text = SkillDescriptions.skillDescriptions[skillInst4.skillId].name;
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

    private void DisplayGameOver(bool winner)
    {
        player1HP.gameObject.SetActive(false);
        player2HP.gameObject.SetActive(false);
        player1Damage.gameObject.SetActive(false);
        player2Damage.gameObject.SetActive(false);
        player1Effects.gameObject.SetActive(false);
        player2Effects.gameObject.SetActive(false);

        playerSkill1.gameObject.SetActive(false);
        playerSkill2.gameObject.SetActive(false);
        playerSkill3.gameObject.SetActive(false);
        playerSkill4.gameObject.SetActive(false);

        gameOver.gameObject.SetActive(true);

        if (!winner) { gameOver.text = "Player 1 wins!"; }
        else { gameOver.text = "Player 2 wins!"; }
    }
}