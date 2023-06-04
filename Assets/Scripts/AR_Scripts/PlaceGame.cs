using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceGame : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject gameBoard;
    private GameObject newGameBoard;

    private Button placeGameBoardButton;

    private void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
        placeGameBoardButton = FindObjectOfType<Button>();
    }

    public void ClickToPlace()
    {
        newGameBoard = Instantiate(gameBoard, placeIndicator.transform.position, placeIndicator.transform.rotation);
        placeIndicator.gameObject.SetActive(false);
        placeGameBoardButton.transform.gameObject.SetActive(false);
    }

}
