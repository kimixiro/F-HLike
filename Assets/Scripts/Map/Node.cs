
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Start,
    Battle,
    Event,
    Shop,
    Boss
}

public class Node
{
    public NodeType Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public GameObject NodeObject { get; set; }
    public List<Node> Neighbors { get; set; }
    public bool Visited { get; set; }

    public Node(NodeType type, int x, int y, GameObject nodeObject)
    {
        Type = type;
        X = x;
        Y = y;
        NodeObject = nodeObject;
        Neighbors = new List<Node>();
    }
}
