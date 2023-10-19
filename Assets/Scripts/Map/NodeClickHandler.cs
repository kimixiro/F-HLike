using System;
using UnityEngine;

public class NodeClickHandler : MonoBehaviour
{
    public Map map;
    public Node node;

    public GameObject shopIcon; // Drag your Shop icon GameObject here
    public GameObject battleIcon; // Drag your Battle icon GameObject here
    public GameObject eventIcon; // Drag your Event icon GameObject here
    public GameObject StartIcon;
    public GameObject BossIcon;

    void Start()
    {
        if (node != null)
        {
            UpdateVisuals();
        }
        else
        {
            Debug.LogError("Node is not initialized.");
        }
    }

    void OnMouseDown()
    {
        if (map != null)
        {
            map.MoveToNode(node);
        }
        else
        {
            Debug.LogError("Map is not initialized.");
        }
    }

    public void UpdateVisuals()
    {
        if (shopIcon == null || battleIcon == null || eventIcon == null || StartIcon == null || BossIcon == null)
        {
            Debug.LogError("One or more icons are not initialized.");
            return;
        }

        // Disable all icons first
        shopIcon.SetActive(false);
        battleIcon.SetActive(false);
        eventIcon.SetActive(false);
        StartIcon.SetActive(false);
        BossIcon.SetActive(false);

        // Enable the appropriate icon based on NodeType
        switch (node.Type)
        {
            case NodeType.Start:
                StartIcon.SetActive(true);
                break;
            case NodeType.Shop:
                shopIcon.SetActive(true);
                break;
            case NodeType.Battle:
                battleIcon.SetActive(true);
                break;
            case NodeType.Event:
                eventIcon.SetActive(true);
                break;
            case NodeType.Boss:
                BossIcon.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}