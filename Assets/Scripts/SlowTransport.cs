using UnityEngine;

public class SlowTransport : MonoBehaviour
{
    private GameObject target;

private void OnTriggerEnter(Collider other)
{
    // If collision with Transport Cube is Ghost, slow down
    if (other.gameObject.CompareTag("Ghost"))
    {
        target = other.gameObject;
        target.GetComponent<Movement>().speedMulti = 0.7f;
        Invoke(nameof(ResetMulti), 1.0f);
    }
}

private void ResetMulti()
{
    target.GetComponent<Movement>().speedMulti = 1.0f;
}
}

