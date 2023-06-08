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

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    private Animator animator;
    public Joystick joystick;
    
    private PlaceGameBoard placeGameBoard;
    public GameObject gameBoard;
    public GameObject player;
    //bool playerFound = false;

    private void Awake() {
        joystick = FindObjectOfType<Joystick> ();
        this.movement = GetComponent<Movement>();
        animator = GetComponentInChildren<Animator> ();
        placeGameBoard = FindObjectOfType<PlaceGameBoard>();
    }

    void Update()
    {
        // For joystick testing
        /*if (placeGameBoard.newGameBoard.activeInHierarchy && !playerFound) {
            GameObject gameBoard = GameObject.FindWithTag("GameBoard");
            player = gameBoard.transform.GetChild(3).gameObject;
            if (player != null) {
                playerFound = true;
            }
        }*/

        // Get input from on screen joystick
        //Vector2 joystickInput = joystick.input;

        // set deadzone value, radius outside of which a joystick input moves pacman
        //float deadzone = 0.4f;

        // only move up/down or left/right
        /*if (Math.Abs(joystickInput.x) > Math.Abs(joystickInput.y)) {
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
        }*/

        // For Keyboard usage
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

