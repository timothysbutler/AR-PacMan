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
