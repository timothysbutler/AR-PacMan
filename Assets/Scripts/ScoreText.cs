using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;
    public String scorePrefix;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        scorePrefix = "1UP\n";
        scoreText = GetComponent<TMPro.TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score = FindObjectOfType<GameManager>().score;
        scoreText.text = scorePrefix + score.ToString();
    }
}
