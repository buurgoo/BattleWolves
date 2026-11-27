using UnityEngine;
using UnityEditor;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public enum InventoryType
    {
        Food,
        Skill
    }

    [SerializeField] private InventoryType inventoryType;
    [SerializeField] private HuntingGroundsItems food;
    [SerializeField] private SkillLevel skillLevel;
    [SerializeField] private TMP_Text countText;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        switch (inventoryType)
        {
            case InventoryType.Food:
                int count = FridgeInventory.GetCount(food);
                countText.text = $"×{count}";
                break;
            
            case InventoryType.Skill:
                int skillCount = SkillsInventory.GetSkillLevel(skillLevel);
                countText.text = $"LVL {skillCount}";
                break;
        }
    }
}