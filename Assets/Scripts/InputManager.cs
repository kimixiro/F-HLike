using DefaultNamespace;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CombatSystem combatSystem;
    private TurnManager turnManager;

    private void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void Update()
    {
        if (!turnManager.IsPlayerTurn) return; // Block input if it's not the player's turn

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                BodyPart targetedPart = DetermineBodyPart(hit.collider);
                if (targetedPart != null)
                {
                    combatSystem.PlayerAttack(targetedPart);
                }
            }
        }
    }


    public BodyPart DetermineBodyPart(Collider collider)
    {
        // Assuming each body part's visual representation has the BodyPart script attached
        return collider.GetComponent<BodyPart>();
    }
}