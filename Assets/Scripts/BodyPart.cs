using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BodyPart", menuName = "Character/BodyPart")]
public class BodyPart : ScriptableObject
{
    public string partName;
    public float DamageMultiplier;
    public bool IsVital;
    public List<StatusEffect> EffectsOnLoss;
    public bool CanBeReplaced;
    public GameObject visualRepresentation; // Reference to the visual representation
}