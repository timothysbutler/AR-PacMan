//-------------------------------------------------------------------//
// Authors: Timothy Butler and Nick Thomas
// Date Last Modified: May 11th, 2023
// Course: CS 467 - 400
// Oregon State University
// Source(s):
// (1) https://www.youtube.com/watch?v=TKt_VlMn_aA
// (2) https://docs.unity3d.com/ScriptReference/Physics.BoxCast.html
// (3) https://noobtuts.com/unity/2d-pacman-game
//-------------------------------------------------------------------//

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed = 6.0f; 
    public float speedMulti = 1.0f;
    public Vector3 initialDirection;
    public LayerMask obstacleLayer;
    public new Rigidbody rigidbody { get; private set; }

    public Vector3 direction { get; private set; }
    public Vector3 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }
    public Vector3 box { get; private set; }

    RaycastHit hit;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.startingPosition = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMulti = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector3.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        // Section was modified from Source(1)
        // If nextDirection is NOT zero, then set the new direction
        if (this.nextDirection != Vector3.zero) {
            SetDirection(this.nextDirection);
        }
        // Continuously check for walls if going in a straight line
        if (Occupied(this.direction)) 
        {
            this.direction = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        // Move the character according to the position and translation
        Vector3 position = this.rigidbody.position;
        Vector3 translation = this.direction * this.speed * this.speedMulti * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector3 direction, bool forced = false)
    {
        // If space is not occupied, set the new direction and reset queue. If occupied, set the queue for next direction
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector3.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector3 direction)
    {
        // This section was modified from Source(1)
        // Set the box for BoxCast size a little smaller than 1x1x1 cube
        this.box = new Vector3(0.94f, 0.94f, 0.94f);
        // Check to see if there is a collision or 'hit' and return boolean
        if (Physics.BoxCast(this.transform.position, this.box /2, direction, out hit, transform.rotation, 0.05f, this.obstacleLayer))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}

