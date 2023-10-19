using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Map Generation Settings")]
    public int mapWidth = 5;
    public int mapHeight = 5;
    public int maxShopNodes = 5;
    public int maxEventNodes = 5;

    [Header("Prefabs and Icons")]
    public GameObject nodePrefab;
    public GameObject heroIcon;

    private List<List<Node>> mapGrid = new List<List<Node>>();
    private Node currentNode;

    public void Start()
    {
        GenerateMap(mapWidth, mapHeight);
        MoveToNode(currentNode);
    }

    public void GenerateMap(int width, int height)
    {
        mapGrid = new List<List<Node>>();
        int shopCount = 0;
        int eventCount = 0;

        for (int y = 0; y < height; y++)
        {
            List<Node> row = new List<Node>();
            for (int x = 0; x < width; x++)
            {
                NodeType type = GenerateNodeType(x, y, width, height, ref shopCount, ref eventCount);
                GameObject nodeObject = Instantiate(nodePrefab, new Vector3(x, y, 0), Quaternion.identity);
                Node node = new Node(type, x, y, nodeObject);
                NodeClickHandler nodeClickHandler = nodeObject.GetComponent<NodeClickHandler>();
                if (nodeClickHandler != null)
                {
                    nodeClickHandler.node = node;
                    nodeClickHandler.map = this;
                    nodeClickHandler.UpdateVisuals();
                }
                row.Add(node);
            }
            mapGrid.Add(row);
        }

        // Set neighbors for each node
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Node node = mapGrid[y][x];
                if (y > 0) node.Neighbors.Add(mapGrid[y - 1][x]);
                if (y < height - 1) node.Neighbors.Add(mapGrid[y + 1][x]);
                if (x > 0) node.Neighbors.Add(mapGrid[y][x - 1]);
                if (x < width - 1) node.Neighbors.Add(mapGrid[y][x + 1]);
            }
        }

        currentNode = mapGrid[0][0];
        heroIcon.transform.position = new Vector3(currentNode.X, currentNode.Y, 0);
        UpdateNodeScales();
    }

    private NodeType GenerateNodeType(int x, int y, int width, int height, ref int shopCount, ref int eventCount)
    {
        if (x == 0 && y == 0) return NodeType.Start;
        if (x == width - 1 && y == height - 1) return NodeType.Boss;

        float rand = UnityEngine.Random.Range(0f, 1f);
        if (rand < 0.2f && shopCount < maxShopNodes)
        {
            shopCount++;
            return NodeType.Shop;
        }
        if (rand < 0.4f && eventCount < maxEventNodes)
        {
            eventCount++;
            return NodeType.Event;
        }

        return NodeType.Battle;
    }

    public void MoveToNode(Node targetNode)
    {
        if (IsNodeReachable(targetNode))
        {
            currentNode.Visited = true;
            currentNode = targetNode;
            heroIcon.transform.position = new Vector3(currentNode.X, currentNode.Y, 0);
            UpdateNodeScales();  
            
        }
        else
        {
            Debug.LogWarning("Target node is not reachable from the current node.");
        }
    }

    private void UpdateNodeScales()
    {
        foreach (var row in mapGrid)
        {
            foreach (var node in row)
            {
                // Set all nodes to normal size
                node.NodeObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
        }

        // Enlarge the current node
        currentNode.NodeObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        // Enlarge only the neighbors that are reachable
        foreach (var neighbor in currentNode.Neighbors)
        {
            if (IsNodeReachable(neighbor))
            {
                neighbor.NodeObject.transform.localScale = new Vector3(1f, 1f, 1);
            }
        }
    }


    public bool IsNodeReachable(Node targetNode)
    {
        return currentNode.Neighbors.Contains(targetNode) && !targetNode.Visited;
    }
}