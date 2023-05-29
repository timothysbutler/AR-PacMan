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
    private Vector3 gameBoardOffset;
    private Vector3 gameBoardScale;

    private GameObject newScoreText;
    public GameObject scoreText;
    private Vector3 scoreTextOffset;
    private Quaternion scoreTextRotation;

    private GameObject newScoreValue;
    public GameObject scoreValue;
    private Vector3 scoreValueOffset;
    private Quaternion scoreValueRotation;

    public Button placeGameBoardButton; 

    // Start is called before the first frame update
    void Start()
    {
        showGameBoardIndicator = FindObjectOfType<ShowGameBoardIndicator> ();
        arPlaneManager = GetComponent<ARPlaneManager> ();

        gameBoard.SetActive(false);
        scoreText.SetActive(false);
        scoreValue.SetActive(false);

        //combine these also to GameBoard
        scoreTextOffset = new Vector3 (-3f, 3f, 20f);
        scoreTextRotation = Quaternion.Euler(0f,0f,0f);

        scoreValueOffset = new Vector3 (-3f, 3f, 20f);
        scoreValueRotation = Quaternion.Euler(0f,0f,0f);

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

        newScoreText = Instantiate(scoreText, showGameBoardIndicator.transform.position+scoreTextOffset, showGameBoardIndicator.transform.rotation*scoreTextRotation);

        if (!newScoreText.activeInHierarchy) {
            {
                newScoreText.SetActive(true);
            }
        }

        newScoreValue = Instantiate(scoreValue, showGameBoardIndicator.transform.position+scoreValueOffset, showGameBoardIndicator.transform.rotation*scoreValueRotation);

        if (!newScoreValue.activeInHierarchy) {
            {
                newScoreValue.SetActive(true);
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