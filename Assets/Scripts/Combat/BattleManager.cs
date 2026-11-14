using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] public BattleWolf player1;
    [SerializeField] public BattleWolf player2;

    private bool _currentTurn = false;
    private Skill _playerSelectedSkill;

    public void Start()
    {
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

    private void TurnStart()
    {
        BattleWolf player = GetPlayer();
        Debug.Log($"Waiting for '{_currentTurn}' player.");
        player.SelectSkill();
    }

    public void PlayerSelectedSkill(BattleWolf player)
    {
        if (player == GetPlayer())
        {
            _playerSelectedSkill = player.selectedSkill;
            TurnContinue();
        }
    }

    private void TurnContinue()
    {
        _playerSelectedSkill.Cast(GetPlayer(), GetOponent());
        Debug.Log($"'{_currentTurn}' player finished turn.");

        _playerSelectedSkill = null;
        SwitchTurn();

        TurnStart();
    }
}
