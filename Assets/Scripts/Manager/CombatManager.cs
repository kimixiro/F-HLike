using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public List<Entity> turnOrder;
    public UIManager uiManager;
    public AnimationAndSoundManager animationAndSoundManager;

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
        int remainingActionPoints = entity.actionPoints;

        while (remainingActionPoints > 0)
        {
            Action selectedAction = entity.ChooseAction();
            Entity targetEntity = ChooseTarget();
            BodyPart targetBodyPart = ChooseTargetBodyPart(targetEntity);
            selectedAction.Execute(entity, targetEntity, targetBodyPart);

            // Play animation and sound based on the action
            animationAndSoundManager.PlayAnimation(selectedAction.actionName);
            animationAndSoundManager.PlaySound(selectedAction.actionName);

            remainingActionPoints--;
        }
    }

    public Entity ChooseTarget()
    {
        // Implement logic for choosing target
        return turnOrder[0];
    }

    public BodyPart ChooseTargetBodyPart(Entity targetEntity)
    {
        // Implement logic for choosing target body part
        return targetEntity.bodyParts[0];
    }
}