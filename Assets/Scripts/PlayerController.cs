using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player playerInput;

    private void Awake() {
        playerInput = new Player();
        controller = GetComponent<CharacterController> ();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private CharacterController controller;
    private Vector3 playerVelocity;

    private float playerSpeed = 0.5f;

    private void Start()
    {

    }

    void Update()
    {
        Vector2 movementInput = playerInput.PlayerMovement.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
