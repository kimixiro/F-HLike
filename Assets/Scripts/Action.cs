using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string actionName;
    public string targetBodyPart;
    public abstract void Execute(Entity user, Entity target, BodyPart targetBodyPart);
}
