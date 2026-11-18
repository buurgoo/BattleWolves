using UnityEngine;

public class AutoBattleWolfAggressive : AutoBattleWolf
{
    private bool firstTurn = true;
    
    protected override void SetType()
    {
        type = SkillType.Aggressive;
    }

    public override void SelectSkill()
    {
        if (firstTurn)
        {
            selectedSkill = new Intimidate();
            firstTurn = false;
        }
        else if (RemainingHP() < 0.5f)
        {
           selectedSkill = new Bite();
        }
        else if (Random.Range(0f, 1f) > 0.3f)
        {
            selectedSkill = new GoForThroat();
        }
        else
        {
            selectedSkill = new Rage();
        }

        battleManager.PlayerSelectedSkill(this);
    }
}