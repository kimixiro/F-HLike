using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string actionName;

    public abstract void Execute(Entity user, Entity target);
}