using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] public BattleWolf player1;
    [SerializeField] public BattleWolf player2;

    [SerializeField] private CombatUI ui;

    private bool _currentTurn = false;

    public void Start()
    {   
        player1.Init();
        player2.Init();
    }

    public void StartCombat() 
    {
        ui.displayHP.Invoke(player1.GetCurrentHP(), player1.GetMaxHP(), false);
        ui.displayHP.Invoke(player2.GetCurrentHP(), player2.GetMaxHP(), true);

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
        BattleWolf player = GetPlayer();
        Debug.Log($"Waiting for '{_currentTurn}' player.");

        LingeringSkillsTick(player);
        ui.displayEffects.Invoke(player.lingeringSkills, _currentTurn);

        if (player.selectedSkill != null) 
        { 
            player.selectedSkill.Cast(player, GetOponent());
        }
        player.SelectSkill();
    }

    public void PlayerSelectedSkill(BattleWolf player)
    {
        if (player == GetPlayer())
        {
            TurnContinue();
        }
    }

    private void TurnContinue()
    {
        BattleWolf player = GetPlayer();
        player.selectedSkill.Cast(player, GetOponent());
        Debug.Log($"'{_currentTurn}' player finished turn.");

        player.selectedSkill = null;
        SwitchTurn();

        TurnStart();
    }
}
