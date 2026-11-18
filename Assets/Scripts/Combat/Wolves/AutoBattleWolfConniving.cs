using UnityEngine;

public class AutoBattleWolfConniving : AutoBattleWolf
{
    protected override void SetType()
    {
        type = SkillType.Conniving;
    }

    public override void SelectSkill()
    {
        if (RemainingHP() > 0.5)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                selectedSkill = new Scratch();
            }
            else { selectedSkill = new PrepareStrike(); }
        }
        else
        {
            if(Random.Range(0f, 1f) > 0.5)
            {
                selectedSkill = new FinishOff();
            }
            else { selectedSkill = new Bite(); }
        }

        battleManager.PlayerSelectedSkill(this);
    }
}