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
//-----------------------------------------------------------//
using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            Vector3 direction = Vector3.zero;
            float minDistance = float.MaxValue;

            foreach (Vector3 availableDirction in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirction.x, availableDirction.y, availableDirction.z);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirction;
                    minDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
