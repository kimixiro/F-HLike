using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BodyPart
{
    public string Name;
    public float DamageMultiplier = 1.0f;
    public bool IsVital = false;
    public List<StatusEffect> EffectsOnLoss = new List<StatusEffect>();
    public bool CanBeReplaced = false;
    public float InitialHealth = 100f;

    public BodyPart(string name, float damageMultiplier, float initialHealth, bool isVital, List<StatusEffect> effectsOnLoss, bool canBeReplaced)
    {
        Name = name;
        DamageMultiplier = damageMultiplier;
        InitialHealth = initialHealth; // Initialize the InitialHealth property
        IsVital = isVital;
        EffectsOnLoss = effectsOnLoss;
        CanBeReplaced = canBeReplaced;
    }
}