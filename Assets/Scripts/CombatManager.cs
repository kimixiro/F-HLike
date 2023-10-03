using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Entity> turnOrder;
    public UIManager uiManager;

    public void StartCombat(List<Entity> entities)
    {
        turnOrder = entities;
        // Initialize combat UI, etc.
    }

    public void HandleCombat()
    {
        foreach (Entity entity in turnOrder)
        {
            ExecuteTurn(entity);
        }
    }

    public void ExecuteTurn(Entity entity)
    {
        Action selectedAction = entity.ChooseAction();
        Entity target = ChooseTarget(); // Now implemented below
        selectedAction.Execute(entity, target);
    }

    public Entity ChooseTarget()
    {
        // Implement your own target selection logic here
        // For now, let's just return the first entity in the turn order as the target
        return turnOrder[0];
    }
}