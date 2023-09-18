using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Character Player;
    public Character Enemy;

    public void PlayerAttack(BodyPart targetPart)
    {
        float damage = Player.AttackPower;
        Enemy.ReceiveDamage(targetPart, damage);
    }

    public void EnemyAttack(BodyPart targetPart)
    {
        float damage = Enemy.AttackPower;
        Player.ReceiveDamage(targetPart, damage);
    }
    
    public void ApplyPeriodicDamage()
    {
        // Apply damage from status effects like bleeding or poison
        // This can be expanded based on the status effects you have
        // For now, as an example, we'll reduce health directly
        Player.Health -= 5; // Example damage to player
        Enemy.Health -= 5; // Example damage to enemy
    }
    
    public IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before the enemy takes an action

        // For simplicity, the enemy will target a random body part of the player
        BodyPart randomPart = Player.BodyParts[Random.Range(0, Player.BodyParts.Count)];
        EnemyAttack(randomPart);
    }

}

