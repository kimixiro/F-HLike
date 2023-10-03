using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState { Exploration, Combat, Dialogue }
    public GameState currentState;

    public CombatManager combatManager;

    void Update()
    {
        switch (currentState)
        {
            case GameState.Combat:
                combatManager.HandleCombat();
                break;
            // Handle other states...
        }
    }
}