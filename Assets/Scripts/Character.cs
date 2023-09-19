using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<BodyPart> bodyParts = new List<BodyPart>();

    public List<BodyPart> BodyParts => bodyParts;
    public float Health = 100f;
    public float AttackPower = 10f;

    private Dictionary<BodyPart, float> bodyPartsHealth = new Dictionary<BodyPart, float>();

    private void Start()
    {
        // Initialize the health of each body part
        foreach (BodyPart part in BodyParts)
        {
            bodyPartsHealth[part] = part.InitialHealth;
        }
    }
    
    public void ReceiveDamage(BodyPart targetPart, float damageAmount)
    {
        // Calculate the actual damage based on the target body part's damage multiplier
        float actualDamage = damageAmount * targetPart.DamageMultiplier;
    
        // Apply the damage to the targeted body part
        if (bodyPartsHealth.ContainsKey(targetPart))
        {
            bodyPartsHealth[targetPart] -= actualDamage;
        }
        else
        {
            bodyPartsHealth[targetPart] = targetPart.InitialHealth - actualDamage;
        }

        // Check if the body part's health is depleted
        if (bodyPartsHealth[targetPart] <= 0)
        {
            Debug.Log($"{gameObject.name}'s {targetPart.Name} has been destroyed.");
            // Disable the visual representation of the lost body part
            GameObject lostPartVisual = GameObject.FindWithTag(targetPart.Name); // or GameObject.Find(targetPart.Name) if using names
            if (lostPartVisual != null)
            {
                lostPartVisual.SetActive(false);
            }

            // Apply status effects associated with losing that body part
            foreach (StatusEffect effect in targetPart.EffectsOnLoss)
            {
                ApplyStatusEffect(effect);
            }

            // If the body part is vital (e.g., head or torso), handle character death
            if (targetPart.IsVital)
            {
                // Handle character death logic here
                // For example, play a death animation, update the game state, etc.
            }
        }
        else
        {
            Debug.Log($"{gameObject.name}'s {targetPart.Name} received {actualDamage} damage. Remaining health: {bodyPartsHealth[targetPart]}.");
        }
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        switch (effect)
        {
            case StatusEffect.Bleeding:
                StartCoroutine(BleedingEffect());
                break;
            case StatusEffect.Weakened:
                AttackPower *= 0.8f;
                break;
            case StatusEffect.Paralyzed:
                // Example: Disable movement or actions for a duration.
                // This would require additional logic or coroutines.
                break;
            // ... (handle other effects)
        }
    }

    private IEnumerator BleedingEffect()
    {
        float bleedDuration = 5f; // 5 seconds for example
        while (bleedDuration > 0)
        {
            Health -= 1f; // Lose 1 health every second
            bleedDuration -= 1f;
            yield return new WaitForSeconds(1f);
        }
    }

    public void ReplaceBodyPart(BodyPart oldPart, BodyPart newPart)
    {
        if (oldPart.CanBeReplaced)
        {
            BodyParts.Remove(oldPart);
            BodyParts.Add(newPart);
            // Handle any effects or changes due to the replacement.
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        // Additional logic for character death can be added here.
    }
}