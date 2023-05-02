using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Player playerInput;
    private Animator animator;
    private void Awake() {
        playerInput = new Player();
        controller = GetComponent<CharacterController> ();
        animator = GetComponentInChildren<Animator> ();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private CharacterController controller;
    private Vector3 playerVelocity;

    public float playerSpeed = 5f;

    private void Start()
    {

    }

    void Update()
    {
        Move();
        //Animate();
    }

    private void Move()
    {
        Vector2 movementInput = playerInput.PlayerMovement.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if(move != Vector3.zero) {
            gameObject.transform.forward = move;
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
        //Debug.Log(movementInput);
    }
}
