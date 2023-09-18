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
            // Start with the PeriodicDamage phase
            currentPhase = TurnPhase.PeriodicDamage;
            combatSystem.ApplyPeriodicDamage();
            yield return new WaitForSeconds(1f); // Wait for a second (or any desired duration)

            // Move to the Action phase
            currentPhase = TurnPhase.Action;
            if (currentTurn == Turn.Player)
            {
                // Wait for the player to take an action
                // This will be handled by the InputManager
            }
            else
            {
                yield return StartCoroutine(combatSystem.EnemyAction());
                EndTurn();
            }
        }
        
        public void EndTurn()
        {
            // Switch to the other character's turn
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