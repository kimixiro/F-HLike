using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Entity> turnOrder;
    public UIManager uiManager;

    public void StartCombat(List<Entity> entities)
    {
        turnOrder = entities;
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
        int remainingActionPoints = entity.actionPoints; // New variable for action points

        while (remainingActionPoints > 0)
        {
            Action selectedAction = entity.ChooseAction();
            Entity targetEntity = ChooseTarget(); // Choose the target entity
            BodyPart targetBodyPart = ChooseTargetBodyPart(targetEntity); // New method to choose target body part
            selectedAction.Execute(entity, targetEntity, targetBodyPart); // Modified to pass BodyPart and Entity

            remainingActionPoints--;
        }
    }

    public Entity ChooseTarget()
    {
        // Implement target entity selection logic here
        return turnOrder[0]; // Placeholder
    }

    public BodyPart ChooseTargetBodyPart(Entity targetEntity)
    {
        // Implement target body part selection logic here based on the target entity's body parts
        return targetEntity.bodyParts[0]; // Placeholder
    }
}