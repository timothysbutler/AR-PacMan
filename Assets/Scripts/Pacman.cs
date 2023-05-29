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
    
    private PlaceGameBoard placeGameBoard;
    public GameObject gameBoard;
    public GameObject player;
    bool playerFound = false;

    private void Awake() {
        joystick = FindObjectOfType<Joystick> ();
        this.movement = GetComponent<Movement>();
        animator = GetComponentInChildren<Animator> ();
        placeGameBoard = FindObjectOfType<PlaceGameBoard>();
        Debug.Log("hello?");
    }

    void Update()
    {
        // get the player object from PlaceGameBoard.cs
        Debug.Log(placeGameBoard.newGameBoard);
        if (placeGameBoard.newGameBoard.activeInHierarchy && !playerFound) {
            GameObject gameBoard = GameObject.FindWithTag("GameBoard");
            if(gameBoard) {
                Debug.Log(gameBoard);
            }
            player = gameBoard.transform.GetChild(3).gameObject;
            if (player != null) {
                Debug.Log(player);
                playerFound = true;
            }
        }

        // Get input from on screen joystick
        Vector2 joystickInput = joystick.input;
        Debug.Log(joystickInput);
        // set deadzone value, radius outside of which a joystick input moves pacman
        float deadzone = 0.4f;

        // only move up/down or left/right
        if (Math.Abs(joystickInput.x) > Math.Abs(joystickInput.y)) {
            if (joystickInput.x > deadzone) {
                this.movement.SetDirection(player.transform.right);
            } else if (joystickInput.x < -deadzone) {
                this.movement.SetDirection(player.transform.right * -1);
            }
        } else if (Math.Abs(joystickInput.x) < Math.Abs(joystickInput.y)){
            if (joystickInput.y > deadzone) {
                this.movement.SetDirection(player.transform.forward);
            } else if (joystickInput.y < -deadzone) {
                this.movement.SetDirection(player.transform.forward * -1);
            }
        }

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

