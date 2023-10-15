using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text entityInfoText;
    public GameObject actionMenu;

    public void UpdateEntityUI(Entity entity)
    {
        string info = "Health: " + entity.bodyParts[0].health; // Example
        entityInfoText.text = info;
    }

    public void ShowActionMenu(List<Action> actions)
    {
        actionMenu.SetActive(true);

        // Populate the action menu with available actions
        for (int i = 0; i < actions.Count; i++)
        {
            Button actionButton = actionMenu.transform.GetChild(i).GetComponent<Button>();
            actionButton.onClick.AddListener(() => actions[i].Execute(null, null, null)); // Placeholder
            Text buttonText = actionButton.GetComponentInChildren<Text>();
            buttonText.text = actions[i].actionName;
        }
    }

    public void HideActionMenu()
    {
        actionMenu.SetActive(false);
    }
}