using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class TurnManager : MonoBehaviour
    {
        public bool IsPlayerTurn { get; private set; } = true;
        public Turn currentTurn { get; private set; } = Turn.Player;
        public TurnPhase currentPhase = TurnPhase.PeriodicDamage;
        public CombatSystem combatSystem;

        public void StartTurn(Turn turn)
        {
            currentTurn = turn;
            IsPlayerTurn = (currentTurn == Turn.Player);
            StartCoroutine(TurnRoutine());
        }

        private IEnumerator TurnRoutine()
        {
            currentPhase = TurnPhase.PeriodicDamage;
            combatSystem.ApplyPeriodicDamage();
            yield return new WaitForSeconds(1f);
            currentPhase = TurnPhase.Action;

            if (currentTurn == Turn.Player)
            {
                // Player's turn logic here
            }
            else
            {
                yield return StartCoroutine(combatSystem.EnemyAction());
                EndTurn();
            }
        }

        public void EndTurn()
        {
            if (currentTurn == Turn.Player)
            {
                StartTurn(Turn.Enemy);
            }
            else
            {
                StartTurn(Turn.Player);
            }
        }
    }
}