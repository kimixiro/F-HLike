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
            case GameState.Exploration:
                // Implement exploration logic here
                break;
            case GameState.Dialogue:
                // Implement dialogue logic here
                break;
        }
    }
}