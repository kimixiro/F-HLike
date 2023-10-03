using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public int stamina;
    public List<Action> availableActions;
    public List<StatusEffect> statusEffects;

    public Action ChooseAction()
    {
        // Implement logic to choose an action
        // For now, just return the first available action
        return availableActions[0];
    }
}