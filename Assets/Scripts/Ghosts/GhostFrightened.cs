using UnityEngine;

public class GhostFrightened : GhostBehavior
{
    public Material newMaterial;
    public Material oldMaterial { get; private set; }


    public bool eaten { get; private set; }



    private void Eaten()
    {
        this.eaten = true;

        Vector3 position = this.ghost.home.inside.position;
        this.ghost.transform.position = position;

        this.ghost.GetComponent<MeshRenderer>().enabled = false;

        this.ghost.home.Enable(8.0f);
    }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        oldMaterial = this.ghost.GetComponent<Renderer>().material;
        this.ghost.GetComponent<Renderer>().material = newMaterial;
    }

    public override void Disable()
    {
        base.Disable();

        
    }

    private void OnEnable()
    {
        this.ghost.movement.speedMulti = 0.5f;
        this.eaten = false;
    }

    private void OnDisable()
    {
        this.ghost.movement.speedMulti = 1.0f;
        this.eaten = false;
        this.ghost.GetComponent<Renderer>().material = oldMaterial;
        this.ghost.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pacman") && this.enabled)
        {
            Eaten();
        }

        Node node = other.GetComponent<Node>();

        if (node != null && this.enabled)
        {
            Vector3 direction = Vector3.zero;
            float maxDistance = float.MinValue;

            foreach (Vector3 availableDirction in node.availableDirections)
            {
                Vector3 newPosition = this.transform.position + new Vector3(availableDirction.x, availableDirction.y, availableDirction.z);
                float distance = (this.ghost.target.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = availableDirction;
                    maxDistance = distance;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
