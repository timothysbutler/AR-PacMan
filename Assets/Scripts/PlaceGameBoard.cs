using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceGameBoard : MonoBehaviour
{
    private ShowGameBoardIndicator showGameBoardIndicator;

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

    public Button placeGameBoardButton; 

    // Start is called before the first frame update
    void Start()
    {
        showGameBoardIndicator = FindObjectOfType<ShowGameBoardIndicator> ();
        gameBoard.SetActive(false);
        player.SetActive(false);
        grid.SetActive(false);

        playerSpawnOffset = new Vector3(0f,0.5f,-4.5f);
        playerScale = new Vector3(4.2f,4.2f,4.2f);
        gridSpawnOffset = new Vector3(0f,0.5f, 0f);
        gridRotationOffset = Quaternion.Euler(0, 180, 0);

        gameBoardOffset = new Vector3(0f, 0f, -2f);
        gameBoardScale = new Vector3(0.55f, 0.55f, 0.55f);

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
        // newPlayer = Instantiate(player, newGameBoard.transform.position+playerSpawnOffset, newGameBoard.transform.rotation);

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


        HideButton();
        HideIndicator();
        // HidePlanes();
    }

    void HideButton() {
        placeGameBoardButton.transform.gameObject.SetActive(false);
    }

    void HideIndicator() {
        showGameBoardIndicator.gameObject.SetActive(false);
    }

    // void HidePlanes() {

    // }
}