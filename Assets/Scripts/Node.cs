//-----------------------------------------------------------//
// Authors: Timothy Butler and Nick Thomas
// Date Last Modified: June 7th, 2023
// Course: CS 497 - 400
// Oregon State University
// Source(s):
// (1) https://www.youtube.com/watch?v=TKt_VlMn_aA
// (2) https://www.youtube.com/watch?v=B34iq4O5ZYI
// (3) https://docs.unity3d.com/Manual/CollidersOverview.html
// (4) https://noobtuts.com/unity/2d-pacman-game
// (5) https://github.com/zigurous/unity-pacman-tutorial
//-----------------------------------------------------------//
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public RaycastHit hit;
    public Vector3 box { get; private set; }
    public List<Vector3> availableDirections { get; private set; }

    private void Start()
    {
        this.availableDirections = new List<Vector3>();

        CheckAvailableDirection(Vector3.forward);
        CheckAvailableDirection(Vector3.back);
        CheckAvailableDirection(Vector3.right);
        CheckAvailableDirection(Vector3.left);
    }

    // Check all available directions at each Node using the BoxCast in Movement.
    private void CheckAvailableDirection(Vector3 direction)
    {
        // This section was modified from Source(1)
        // Set the box for BoxCast size a little smaller than 1x1x1 cube
        this.box = new Vector3(0.93f, 0.93f, 0.93f);
        // Check to see if there is a collision or 'hit'
        // If there is no collision, then add direction to list of potential ways
        if (!Physics.BoxCast(this.transform.position, this.box / 2, direction, out hit, transform.rotation, 0.07f, this.obstacleLayer))
        {
            this.availableDirections.Add(direction);
        }
    }
}
