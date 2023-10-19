using UnityEngine;
using System.Collections.Generic;

public class BodyPart : MonoBehaviour
{
    public string partName;
    public int health;
    public List<StatusEffect> statusEffects = new List<StatusEffect>();

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Handle body part destruction logic here
        }
    }

    public void ApplyStatusEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        statusEffects.Remove(effect);
    }

    public void UpdateStatusEffects()
    {
        foreach (StatusEffect effect in statusEffects)
        {
            effect.ApplyEffect(this);
        }
    }
}