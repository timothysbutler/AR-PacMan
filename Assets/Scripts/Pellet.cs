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

public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
    }

    // If collision with Pac-Man, get eaten
    private void OnTriggerEnter(Collider other)
    {
        // If collision with Pac-Man, get eaten
        if (other.gameObject.tag == "Pacman") {
            Eat();
        }
    }
}
