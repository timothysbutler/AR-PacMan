using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Vector3> availableDirections { get; private set; }

    private void Start()
    {
        this.availableDirections = new List<Vector3>();
    }
}
