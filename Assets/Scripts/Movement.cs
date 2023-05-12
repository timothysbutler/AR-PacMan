using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMulti = 1.0f;
    public Vector3 initialDirection;
    public LayerMask obstacleLayer;
    public Rigidbody rigidbody { get; private set; }

    public Vector3 direction { get; private set; }
    public Vector3 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }

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
        if (this.nextDirection != Vector3.zero) {
            SetDirection(this.nextDirection);
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = this.rigidbody.position;
        Vector3 translation = this.direction * this.speed * this.speedMulti * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector3 direction, bool forced = false)
    {
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

    // !!WORKING ON THIS!! //
    public bool Occupied(Vector3 direction)
    {
        if (Physics.BoxCast(this.transform.position, transform.localScale /2, direction, out hit, transform.rotation, 1.1f, this.obstacleLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}