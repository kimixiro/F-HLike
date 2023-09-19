using DefaultNamespace;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CombatSystem combatSystem; // Reference to the CombatSystem
    public TurnManager turnManager;   // Reference to the TurnManager

    private void Update()
    {
        // Check if it's the player's turn
        if (turnManager.currentTurn == Turn.Player)
        {
            // Check for a mouse click
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    BodyPart targetedBodyPart = DetermineBodyPart(hit.collider);

                    if (targetedBodyPart != null)
                    {
                        // Handle the attack logic here
                        combatSystem.PlayerAttack(targetedBodyPart);
                    }
                }
            }
        }
    }

    private BodyPart DetermineBodyPart(Collider collider)
    {
        // Get the Character component from the clicked GameObject's parent or itself
        Character targetCharacter = collider.transform.GetComponentInParent<Character>();

        // If the clicked GameObject is the player or doesn't have a Character component, return null
        if (targetCharacter == null || targetCharacter == combatSystem.Player)
        {
            return null;
        }

        string tag = collider.gameObject.tag;

        foreach (BodyPart part in targetCharacter.BodyParts)
        {
            if (part.Name == tag)
            {
                return part;
            }
        }

        return null; // Return null if no matching body part is found
    }
}