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
        if (!turnManager.IsPlayerTurn) return;

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
        return collider.GetComponent<BodyPart>();
    }
}