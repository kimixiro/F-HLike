using System.Collections;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Character Player;
    public Character Enemy;

    public void PlayerAttack(BodyPart targetPart)
    {
        float damage = Player.AttackPower;
        Enemy.ReceiveDamage(targetPart, damage);
        Debug.Log($"Player attacked {Enemy.name}'s {targetPart.Name}. Enemy's health is now: {Enemy.Health}.");
    }

    public IEnumerator EnemyAction()
    {
        // Wait for a short delay to simulate the enemy thinking
        yield return new WaitForSeconds(1f);

        // Randomly select a body part to attack
        BodyPart[] bodyParts = (BodyPart[])System.Enum.GetValues(typeof(BodyPart));
        BodyPart randomTarget = bodyParts[Random.Range(0, bodyParts.Length)];

        EnemyAttack(randomTarget);
    }

    public void EnemyAttack(BodyPart targetPart)
    {
        float damage = Enemy.AttackPower;
        Player.ReceiveDamage(targetPart, damage);
        Debug.Log($"Enemy attacked Player's {targetPart.Name}. Player's health is now: {Player.Health}.");
    }
    public void ApplyPeriodicDamage()
    {
        Player.Health -= 5;  // This can be modified based on status effects in the future
        Enemy.Health -= 5;  // This can be modified based on status effects in the future
    }
}