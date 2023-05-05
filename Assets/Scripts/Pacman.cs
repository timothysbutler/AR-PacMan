using UnityEngine;

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            this.movement.SetDirection(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            this.movement.SetDirection(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            this.movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            this.movement.SetDirection(Vector2.right);
        }
    }
}
