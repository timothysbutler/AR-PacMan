//-----------------------------------------------------------//
// Authors: Timothy Butler and Nick Thomas
// Date Last Modified: June 7th, 2023
// Course: CS 497 - 400
// Oregon State University
// Source(s):
// (1) https://github.com/zigurous/unity-pacman-tutorial
//-----------------------------------------------------------//
using UnityEngine;

public class SlowTransport : MonoBehaviour
{
    private GameObject target;

private void OnTriggerEnter(Collider other)
{
    // If collision with Transport Cube is Ghost, slow down
    if (other.gameObject.CompareTag("Ghost"))
    {
        CancelInvoke();
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

