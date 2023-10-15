using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string actionName;
    public string targetBodyPart; // New field to specify which body part this action targets

    public abstract void Execute(Entity user, Entity target, BodyPart targetBodyPart);
}