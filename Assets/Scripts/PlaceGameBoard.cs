using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceGameBoard : MonoBehaviour
{
    private ShowGameBoardIndicator showGameBoardIndicator;
    public ARPlaneManager arPlaneManager;

    public GameObject newGameBoard;
    public GameObject gameBoard;

    public Button placeGameBoardButton; 

    // Start is called before the first frame update
    void Start()
    {
        showGameBoardIndicator = FindObjectOfType<ShowGameBoardIndicator> ();
        arPlaneManager = GetComponent<ARPlaneManager> ();

        gameBoard.SetActive(false);

        placeGameBoardButton = GameObject.FindObjectOfType<Button> ();
    }

    public void ClickToPlace()
    {
        newGameBoard = Instantiate(gameBoard, showGameBoardIndicator.transform.position, showGameBoardIndicator.transform.rotation*Quaternion.Euler(0,180,0));
        if (!newGameBoard.activeInHierarchy) {
            {
                newGameBoard.SetActive(true);
            }
        }

        HideButton();
        HideIndicator();
        stopPlaneDetection();
    }

    void HideButton() {
        placeGameBoardButton.transform.gameObject.SetActive(false);
    }

    void HideIndicator() {
        showGameBoardIndicator.gameObject.SetActive(false);
    }

    // comment this function for testing on simulator
    void stopPlaneDetection() {
        // hide currently detected/tracked planes
        // foreach (ARPlane plane in arPlaneManager.trackables) {
        //     plane.gameObject.SetActive(false);
        // }

        // stop detection of new planes
        // arPlaneManager.enabled = false;
    }
}