using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public string effectName;
    public int duration;

    public void ApplyEffect(Entity target)
    {
        // Implement logic for applying effect to the entire entity
    }

    public void ApplyEffect(BodyPart target)
    {
        // Implement logic for applying effect to a specific body part
    }

    public void UpdateEffect()
    {
        duration--;
        if (duration <= 0)
        {
            // Remove this status effect
            Destroy(this);
        }
    }
}