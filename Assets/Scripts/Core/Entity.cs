using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<BodyPart> bodyParts;
    public List<Action> availableActions;
    public List<StatusEffect> statusEffects;
    public int actionPoints;

    public Action ChooseAction()
    {
        // Implement logic for choosing an action
        // For now, return the first available action as a placeholder
        return availableActions[0];
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        statusEffects.Remove(effect);
    }

    public void UpdateStatusEffects()
    {
        foreach (StatusEffect effect in statusEffects)
        {
            effect.ApplyEffect(this);
        }
    }
}