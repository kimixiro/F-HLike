using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<BodyPart> BodyParts = new List<BodyPart>();
    public float Health = 100f;
    public float AttackPower = 10f;

    public void ReceiveDamage(BodyPart targetPart, float damage)
    {
        Health -= damage * targetPart.DamageMultiplier;
        if (Health <= 0 && targetPart.IsVital)
        {
            Die();
            return;
        }
        foreach (var effect in targetPart.EffectsOnLoss)
        {
            ApplyStatusEffect(effect);
        }
        if (Health <= 0)
        {
            // Disable the visual representation of the body part
            targetPart.visualRepresentation.SetActive(false);
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