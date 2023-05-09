using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ShowGameBoardIndicator: MonoBehaviour
{
    private ARRaycastManager raycastManager;
   

    private GameObject gameBoard;
    private List<ARRaycastHit> hits = new List<ARRaycastHit> ();

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager> ();
        gameBoard = transform.GetChild(0).gameObject;
        gameBoard.SetActive(false);
    }

    void Update()
    {
        var ray = new Vector2(Screen.width/2, Screen.height/2);

        if (raycastManager.Raycast(ray, hits, TrackableType.Planes)) {
            Pose hitPose = hits[0].pose;

            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;

            if (!gameBoard.activeInHierarchy)
            {
                gameBoard.SetActive(true);
            }
        }
    }
}