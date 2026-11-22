using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [SerializeField] public BattleWolf player1;
    [SerializeField] public BattleWolf player2;

    [SerializeField] private CombatUI ui;
    
    [Header("Match Rewards")]
    [SerializeField] private float winXPReward = 50f;
    [SerializeField] private int winMoneyReward = 25;

    private bool _currentTurn = false;
    private bool _isCombatOver = false;

    public void Start()
    {   
        player1.Init();
        player2.Init();
    }

    public void StartCombat() 
    {
        ui.displayHP.Invoke(player1.CurrentHP(), player1.MaxHP(), false);
        ui.displayHP.Invoke(player2.CurrentHP(), player2.MaxHP(), true);

        TurnStart(); 
    }

    private void SwitchTurn()
    {
        if (_currentTurn) { _currentTurn = false; }
        else _currentTurn = true;
    }

    private BattleWolf GetPlayer()
    {
        if (_currentTurn) return player2;
        else return player1;
    }

    private BattleWolf GetOponent()
    {
        if (_currentTurn) return player1;
        else return player2;
    }

    private void LingeringSkillsTick(BattleWolf player)
    {
        for (int i = 0; i < player.lingeringSkills.Length; i++)
        {
            if (player.lingeringSkills[i] != null)
            {
                if (player.lingeringSkills[i].isActive)
                {
                    player.lingeringSkills[i].Tick(player);
                }
                else { player.lingeringSkills[i] = null; }
            }
        }
    }

    private void TurnStart()
    {
        if (_isCombatOver) return;
        
        BattleWolf player = GetPlayer();
        Debug.Log($"Waiting for '{_currentTurn}' player.");

        LingeringSkillsTick(player);
        ui.displayEffects.Invoke(player.lingeringSkills, _currentTurn);

        if (player.selectedSkill != null) 
        { 
            player.selectedSkill.Cast(player, GetOponent());
            player.RecordUsedSkill(player.selectedSkill);
            ui.displayAttack.Invoke(player.selectedSkill, _currentTurn);
            player.selectedSkill = null;
            
            if (CheckCombatEnd()) return;
        }
        player.SelectSkill();
    }

    public void PlayerSelectedSkill(BattleWolf player)
    {
        if (_isCombatOver) return;
        
        if (player == GetPlayer())
        {
            TurnContinue();
        }
    }

    private void TurnContinue()
    {
        BattleWolf player = GetPlayer();
        player.selectedSkill.Cast(player, GetOponent());
        player.RecordUsedSkill(player.selectedSkill);
        ui.displayAttack.Invoke(player.selectedSkill, _currentTurn);
        Debug.Log($"'{_currentTurn}' player finished turn.");

        player.selectedSkill = null;

        if (CheckCombatEnd()) return;

        SwitchTurn();
        TurnStart();
    }
    
    private bool CheckCombatEnd()
    {
        if (player1.CurrentHP() <= 0 || player2.CurrentHP() <= 0)
        {
            _isCombatOver = true;
            bool player2Won = player1.CurrentHP() <= 0;
            BattleWolf winner = player2Won ? player2 : player1;

            float awardedXP = 0f;
            int awardedMoney = 0;

            if (!player2Won)
            {
                awardedXP = winXPReward;
                awardedMoney = winMoneyReward;
                System.WolfSessionData.AddRewards(awardedXP, awardedMoney);
            }

            ui.ShowEndCombatPopup(
                winnerName: player2Won ? "Player 2" : "Player 1",
                remainingHP: winner.CurrentHP(),
                maxHP: winner.MaxHP(),
                usedSkills: winner.usedSkills,
                xpReward: awardedXP,
                moneyReward: awardedMoney
            );

            return true;
        }

        return false;
    }
}
