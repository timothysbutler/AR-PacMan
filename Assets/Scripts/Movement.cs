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

    public RaycastHit hit;

    private Animator animator;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.startingPosition = this.transform.position;
        animator = GetComponentInChildren<Animator> ();

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
            //animator.SetBool("isMoving", true);  // animate pac=man's mouth if moving
        }
        // Continuously check for walls if going in a straight line
        if (Occupied(this.direction)) 
        {
            this.direction = Vector3.zero;
            //animator.SetBool("isMoving", false);  // turn off animation if stopped
        }
    }

    private void FixedUpdate()
    {
        // Move the character according to the position and translation
        Vector3 position = this.rigidbody.position;
        Vector3 translation = this.direction * this.speed * this.speedMulti * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation);
        // Rotate the character based on direction of travel
        this.rigidbody.rotation = rotate(translation);

        // Animate Pac-Man
        if (this.gameObject.CompareTag("Pacman")) {
            animate(translation);
        }
        
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
        this.box = new Vector3(transform.parent.localScale.x, transform.parent.localScale.y, transform.parent.localScale.z) * 0.93f;
        // Check to see if there is a collision or 'hit' and return boolean
        if (Physics.BoxCast(this.transform.position, this.box /2, direction, out hit, transform.rotation, transform.parent.localScale.x * 0.07f, this.obstacleLayer))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public Quaternion rotate(Vector3 translation) {
        // define the rotation needed for pac-man based on the direction of travel
        if (this.gameObject.CompareTag("Pacman"))
        {
            if (translation.x > 0) {
                return Quaternion.Euler(0, 270, 0);
            } else if (translation.x < 0) {
                return Quaternion.Euler(0, 90, 0);
            } else if (translation.z > 0) {
                return Quaternion.Euler(0, 180, 0);
            } else if (translation.z < 0) {
                return Quaternion.Euler(0, 0, 0);
            }
        // For Ghost rotation
        } else if (this.gameObject.CompareTag("Ghost")) {
            if (translation.x > 0) {
                return Quaternion.Euler(-90, 0, 0);
            } else if (translation.x < 0) {
                return Quaternion.Euler(-90, 180, 0);
            } else if (translation.z > 0) {
                return Quaternion.Euler(-90, 270, 0);
            } else if (translation.z < 0) {
                return Quaternion.Euler(-90, 90, 0);
            }
        }
        // else keep the current rotational orientation
        return Quaternion.Euler(this.rigidbody.rotation.eulerAngles);
    }

    public void animate(Vector3 translation) 
    {
        // Update Animation of character, whether moving/not-moving        
        if (translation != Vector3.zero) {
            animator.SetBool("isMoving", true);  // animate pac-man's mouth if moving
        } else {
            animator.SetBool("isMoving", false);  // turn off animation if not moving
        }
    }
}

