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

public class Energizer : MonoBehaviour
{
    public int points = 50;
    public float duration = 8.0f;

    protected virtual void EnergizerEat()
    {
        FindObjectOfType<GameManager>().EnergizerEaten(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pacman") {
            EnergizerEat();
        }
    }
}