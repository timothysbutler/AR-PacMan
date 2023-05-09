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

    private GameObject newGameBoard;
    public GameObject gameBoard;
    private Vector3 gameBoardOffset;
    private Vector3 gameBoardScale;

    private GameObject newPlayer;
    public GameObject player;
    private Vector3 playerSpawnOffset;
    private Vector3 playerScale;

    private GameObject newGrid;
    public GameObject grid;
    private Vector3 gridSpawnOffset;
    private Quaternion gridRotationOffset;

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
        player.SetActive(false);
        grid.SetActive(false);
        scoreText.SetActive(false);
        scoreValue.SetActive(false);

        playerSpawnOffset = new Vector3(0f,0.5f,-4.5f);
        playerScale = new Vector3(4.2f,4.2f,4.2f);

        gridSpawnOffset = new Vector3(0f,0.5f, 0f);
        gridRotationOffset = Quaternion.Euler(0, 180, 0);

        gameBoardOffset = new Vector3(0f, 0f, -2f);
        gameBoardScale = new Vector3(0.55f, 0.55f, 0.55f);

        scoreTextOffset = new Vector3 (-3f, 3f, 20f);
        scoreTextRotation = Quaternion.Euler(0f,0f,0f);

        scoreValueOffset = new Vector3 (-3f, 3f, 20f);
        scoreValueRotation = Quaternion.Euler(0f,0f,0f);

        placeGameBoardButton = GameObject.FindObjectOfType<Button> ();
    }

    public void ClickToPlace()
    {
        newGameBoard = Instantiate(gameBoard, showGameBoardIndicator.transform.position+gameBoardOffset, showGameBoardIndicator.transform.rotation);
        newGameBoard.transform.localScale = gameBoardScale;
        if (!newGameBoard.activeInHierarchy) {
            {
                newGameBoard.SetActive(true);
            }
        }
        newPlayer = Instantiate(player, showGameBoardIndicator.transform.position+playerSpawnOffset, newGameBoard.transform.rotation);
        newPlayer.transform.localScale = playerScale;
        if (!newPlayer.activeInHierarchy) {
            {
                newPlayer.SetActive(true);
                newPlayer.tag = "Pacman";
            }
        }

        newGrid = Instantiate(grid, showGameBoardIndicator.transform.position+gridSpawnOffset, showGameBoardIndicator.transform.rotation*gridRotationOffset);

        if (!newGrid.activeInHierarchy) {
            {
                newGrid.SetActive(true);
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