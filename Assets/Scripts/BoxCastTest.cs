using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastTest : MonoBehaviour
{
    public LayerMask obstacleLayer;
    void Start()
    {

    }

    void Update()
    {

    }

    void OnDrawGizmos()
    {
        float maxDistance = 100f;
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale /2, transform.forward, out hit, transform.rotation, maxDistance, this.obstacleLayer);
        if (isHit)
        {
            print("HIT");
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
