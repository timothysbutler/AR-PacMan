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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    private Animator animator;
    public Joystick joystick;

    private void Awake() {
        //joystick = FindObjectOfType<Joystick> ();
        // playerInput = new Player();
        this.movement = GetComponent<Movement>();
        animator = GetComponentInChildren<Animator> ();
    }

    void Update()
    {
        //UNCOMMENT FOR JOYSTICK//

        // Get input from on screen joystick
        //Vector2 joystickInput = joystick.input;

        // only move up/down or left/right
        // if (Math.Abs(joystickInput.x) > Math.Abs(joystickInput.y)) {
        //     if (joystickInput.x > 0.2) {  // Deadzone of 0.2
        //         this.movement.SetDirection(Vector2.right);
        //         ////this.rotation = this.rotation*Quaternion.AngleAxis(joystickInput.x, Vector3.forward);
        //     } else if (joystickInput.x < -0.2) {  // Deadzone of 0.2
        //         this.movement.SetDirection(Vector2.left);
        //     }
        // } else if (Math.Abs(joystickInput.x) < Math.Abs(joystickInput.y)){
        //     if (joystickInput.y > 0.2) {  // Deadzone of 0.2 
        //         this.movement.SetDirection(Vector3.forward);
        //     } else if (joystickInput.y < -0.2) {  // Deadzone of 0.2
        //         this.movement.SetDirection(Vector3.back);
        //     }
        // }

        // For Keyboard testing
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.movement.SetDirection(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.movement.SetDirection(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.movement.SetDirection(Vector2.left);
        }
    }

    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }
}

