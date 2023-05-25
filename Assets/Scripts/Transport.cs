//-----------------------------------------------------------//
// Authors: Timothy Butler and Nick Thomas
// Date Last Modified: May 11th, 2023
// Course: CS 467 - 400
// Oregon State University
// Source(s):
// (1) https://www.youtube.com/watch?v=TKt_VlMn_aA
// (2) https://www.youtube.com/watch?v=B34iq4O5ZYI
// (3) https://docs.unity3d.com/Manual/CollidersOverview.html
// (4) https://noobtuts.com/unity/2d-pacman-game
//-----------------------------------------------------------//

using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform connection;
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        // If collision with Transport Cube is Pacman, transport
        if (other.gameObject.CompareTag("Ghost"))
        {
            target = other.gameObject;
            target.GetComponent<Movement>().speedMulti = 0.5f;
            Invoke(nameof(ResetMulti), 0.5f);
        }
        Vector3 position = connection.position;
        other.transform.position = position;
    }

    private void ResetMulti()
    {
        target.GetComponent<Movement>().speedMulti = 1.0f;
    }
}
