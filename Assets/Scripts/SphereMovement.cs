using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Joystick;

public class MoveSphere : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 5f;

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
