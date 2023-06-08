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

public class Transport : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter(Collider other)
    {
        // If collision with Transport Cube, transport
        Vector3 position = connection.position;
        other.transform.position = position;
    }
}
