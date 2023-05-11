using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public Vector3 box;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        this.box = new Vector3(0.94f, 0.94f, 0.94f);
        float maxDistance = 100f;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, this.box /2, transform.forward, out hit, transform.rotation, maxDistance, this.obstacleLayer);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, this.box);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
