// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Energizer : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;

public class Energizer : MonoBehaviour
{
    public int points = 50;

    protected virtual void EnergizerEat()
    {
        FindObjectOfType<GameManager>().EnergizerEaten(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pacman") {
            Debug.Log("collision with energizer");
            EnergizerEat();
        }
    }
}