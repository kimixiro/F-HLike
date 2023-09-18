using System.Collections.Generic;
using UnityEngine;

public class MindManager : MonoBehaviour
{
    public float mindValue = 100f;
    public List<FearType> fears = new List<FearType>();

    public void ReduceMind(float amount)
    {
        mindValue -= amount;
        if (mindValue < 0)
            mindValue = 0;
    }

    public void AddFear(FearType fear)
    {
        if (!fears.Contains(fear))
            fears.Add(fear);
    }
}