using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pacman") {
            Debug.Log("ate pellet");
            Eat();
        }
    }
}
