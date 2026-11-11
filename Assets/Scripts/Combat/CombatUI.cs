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

    public UnityEvent<int, int, bool> displayHP;
    public UnityEvent<int, bool> displayDamage;

    public void Start()
    {
        displayHP.AddListener(DisplayHP);
        displayDamage.AddListener(DisplayDamage);
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
}