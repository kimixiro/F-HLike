using System.Collections.Generic;
using UnityEngine;

public class BodyPart
{
    public string Name { get; private set; } // Name or tag of the visual representation
    public float DamageMultiplier { get; private set; }
    public float InitialHealth { get; private set; } // Added this property
    public bool IsVital { get; private set; }
    public List<StatusEffect> EffectsOnLoss { get; private set; }
    public bool CanBeReplaced { get; private set; }

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