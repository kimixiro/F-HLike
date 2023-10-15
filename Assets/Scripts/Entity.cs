using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<BodyPart> bodyParts; // New field to hold body parts
    public List<Action> availableActions;
    public List<StatusEffect> statusEffects;
    public int actionPoints; // New field for action points

    public Action ChooseAction()
    {
        // Implement action selection logic here
        return availableActions[0];
    }
}