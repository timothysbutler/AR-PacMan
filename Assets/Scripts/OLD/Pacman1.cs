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

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// public class Pacman : MonoBehaviour
// {
//     public Movement movement { get; private set; }
//     private Player playerInput;
//     private Animator animator;
//     private void Awake() {
//         playerInput = new Player();
//         //controller = GetComponent<CharacterController> ();
//         animator = GetComponentInChildren<Animator> ();
//     }

//     private void OnEnable() {
//         playerInput.Enable();
//     }

//     private void OnDisable() {
//         playerInput.Disable();
//     }

//     private CharacterController controller;
//     private Vector3 playerVelocity;

//     public float playerSpeed = 5f;

//     private void Start()
//     {

//     }

//     void Update()
//     {
//         Move();
//     }

//     private void Move()
//     {
//         // Get X/Y values from joystick input and translate to movement in 3D
//         Vector2 movementInput = playerInput.PlayerMovement.Move.ReadValue<Vector2>();
//         Vector3 move = new Vector3 (movementInput.x,0f,movementInput.y);
//         Vector3 xOnly = new Vector3 (1f,0f,0f);
//         Vector3 yOnly = new Vector3 (0f, 0f, 1f);

//         // only move up/down or left/right
//         if (Math.Abs(movementInput.x) > Math.Abs(movementInput.y)) {
//             move = Vector3.Scale(move, xOnly);
//         } else {
//             move = Vector3.Scale(move, yOnly);
//         }

        
//         //controller.Move(move * Time.deltaTime * playerSpeed);
//         if(move != Vector3.zero) {
//             gameObject.transform.forward = move;
//             animator.SetBool("isMoving", true);
//         } else {
//             animator.SetBool("isMoving", false);
//         }
//     }

//     // private void Awake()
//     // {
//     //     this.movement = GetComponent<Movement>();
//     // }

//     // private void Update()
//     // {
//     //     if (Input.GetKeyDown(KeyCode.UpArrow)) {
//     //         this.movement.SetDirection(Vector3.back);
//     //     }
//     //     else if (Input.GetKeyDown(KeyCode.DownArrow)) {
//     //         this.movement.SetDirection(Vector3.forward);
//     //     }
//     //     else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
//     //         this.movement.SetDirection(Vector2.right);
//     //     }
//     //     else if (Input.GetKeyDown(KeyCode.RightArrow)) {
//     //         this.movement.SetDirection(Vector2.left);
//     //     }
//     // }
// }
