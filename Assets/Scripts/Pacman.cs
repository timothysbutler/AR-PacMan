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

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.movement.SetDirection(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            this.movement.SetDirection(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            this.movement.SetDirection(Vector2.left);
        }
    }
}
