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
        return availableActions[0];
    }
}