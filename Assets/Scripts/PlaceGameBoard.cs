using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceGameBoard : MonoBehaviour
{
    private ShowGameBoardIndicator showGameBoardIndicator;

    private GameObject newGameBoard;
    public GameObject gameBoard;

    private GameObject newPlayer;
    public GameObject player;
    private Vector3 playerSpawnOffset;

    public Button placeGameBoardButton;

    // Start is called before the first frame update
    void Start()
    {
        showGameBoardIndicator = FindObjectOfType<ShowGameBoardIndicator> ();
        gameBoard.SetActive(false);
        player.SetActive(false);
        playerSpawnOffset = new Vector3(0f,-0.17f,0.5f);
        placeGameBoardButton = GameObject.FindObjectOfType<Button> ();
    }

    public void ClickToPlace()
    {
        newGameBoard = Instantiate(gameBoard, showGameBoardIndicator.transform.position, showGameBoardIndicator.transform.rotation);
        if (!newGameBoard.activeInHierarchy) {
            {
                newGameBoard.SetActive(true);
            }
        }
        newPlayer = Instantiate(player, showGameBoardIndicator.transform.position-playerSpawnOffset, showGameBoardIndicator.transform.rotation);
        if (!newPlayer.activeInHierarchy) {
            {
                newPlayer.SetActive(true);
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