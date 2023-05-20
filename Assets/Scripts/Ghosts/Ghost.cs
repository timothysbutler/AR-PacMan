using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    public GhostBehavior initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.home = GetComponent<GhostHome>();
        this.scatter = GetComponent<GhostScatter>();
        this.chase = GetComponent<GhostChase>();
        this.frightened = GetComponent<GhostFrightened>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);

        this.frightened.Disable();
        this.chase.Disable();
        this.scatter.Enable();

        if (this.home != this.initialBehavior) {
            this.home.Disable();
        }

        if (this.initialBehavior != null) {
            this.initialBehavior.Enable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pacman")
        {
            if (this.frightened.enabled) {
                FindObjectOfType<GameManager>().GhostEaten(this);
            } else {
                FindAnyObjectByType<GameManager>().PacmanEaten();
            }
        }
    }
}