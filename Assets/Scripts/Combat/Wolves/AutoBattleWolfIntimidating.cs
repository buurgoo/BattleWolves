using UnityEngine;

public class AutoBattleWolfIntimidating : AutoBattleWolf
{
    protected override void SetType()
    {
        type = SkillType.Intimidating;
    }

    public override void SelectSkill()
    {
        if (RemainingHP() > 0.8)
        {
            selectedSkill = new BodySlam();
        }
        else if (RemainingHP() < 0.2)
        {
            if (Random.Range(0f, 1f) > 0.5)
            {
                selectedSkill = new LickWounds();
            }
            else { selectedSkill = new PrepareStrike(); }
        }
        else 
        {
            if (Random.Range(0f, 1f) > 0.4)
            {
                selectedSkill = new BodySlam();
            }
            else { selectedSkill = new Intimidate(); }
        }

        battleManager.PlayerSelectedSkill(this);
    }
}