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
using UnityEngine;

public class GhostScatter : GhostBehavior
{
    // When disabled, enable Chase behavior
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }

    // If collision with Node, determine next direciton
    private void OnTriggerEnter(Collider other)
    {
        Node node = other.GetComponent<Node>();

        // Generate random direction that is avaiable at the node
        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            if (node.availableDirections[index] == -this.ghost.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            // Set the direction
            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
