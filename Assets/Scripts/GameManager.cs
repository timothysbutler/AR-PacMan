//-----------------------------------------------------------//
// Authors: Timothy Butler and Nick Thomas
// Date Last Modified: May 11th, 2023
// Course: CS 497 - 400
// Oregon State University
// Source(s):
// (1) https://www.youtube.com/watch?v=TKt_VlMn_aA
// (2) https://www.youtube.com/watch?v=B34iq4O5ZYI
// (3) https://docs.unity3d.com/Manual/CollidersOverview.html
// (4) https://noobtuts.com/unity/2d-pacman-game
//-----------------------------------------------------------//

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    //public PlayerController pacman;
    public Transform pellets;
    public Energizer energizer;

    public int ghostMulti { get; private set; }
    public int score { get; private set; }
    public int lives { get; private set; }

    public AudioSource starting;
    public AudioSource siren;
    public AudioSource munch1;
    public AudioSource munch2;
    public AudioSource powerUp;
    public AudioSource ghostEaten;
    public AudioSource death;
    public AudioSource gameOver;
    private int munchNumber = 0;

    // Start the Game
    private void Start()
    {
        // Play starting Music and display "Ready!"
        StartingGame();
        Invoke(nameof(NewGame), 3.0f);
        
    }

    // Run at the beginning and at restart
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    // New Round, Set everything back and increase variables (if needed)
    private void NewRound()
    {
        // Play Siren
        siren.Play();

        ResetGhostMulti();
        foreach(Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    // If death, reset the player and ghosts, but keep pellets.
    private void ResetState()
    {

        // Play Siren
        siren.Play();

        ResetGhostMulti();
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].ResetState();
        }

        this.pacman.ResetState();
    }

    // All lives have been loss, game ends
    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);

    }

    // Set the current score
    private void SetScore(int score)
    {
        this.score = score;
    }

    // Set the current lives
    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    // If Ghosts are eaten, increase score and score multiplyer, and then reset ghosts
    public void GhostEaten(Ghost ghost)
    {
        ghostEaten.Play();
        int points = ghost.points * this.ghostMulti;
        SetScore(this.score + points);
        this.ghostMulti++;
    }

    // Player gets eaten, reset board, and lose a life
    public void PacmanEaten()
    {

        // Stop playing siren
        siren.Stop();

        this.pacman.gameObject.transform.position = Vector3.zero;
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0) {
            // Play death
            death.Play();

            Invoke(nameof(ResetState), 3.0f);
        } else {
            // Play gameover death
            gameOver.Play();
            GameOver();
        }
    }

    // Add to score if pellet is eaten, check to see if all have been eaten, if so new round begins
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);

        if (munchNumber == 0)
        {
            munch1.Play();
            munchNumber = 1;
        }
        else if (munchNumber == 1)
        {
            munch2.Play();
            munchNumber = 0;
        }

        if (!CheckPelletCount())
        {
            Debug.Log("All Gone");
            //this.pacman.gameObject.SetActive(false);
            //Invoke(nameof(NewRound), 3.0f);
        }
    }

    // If energizer gets eaten, increase score, turn ghosts to blue
    public void EnergizerEaten(Energizer energizer)
    {

        powerUp.Play();
        energizer.gameObject.SetActive(false);

        SetScore(this.score + energizer.points);
        //CancelInvoke();
        //Invoke(nameof(ResetGhostMulti), energizer.duration);
        // power up pacman
        // ghosts scared
    }

    // Check the pellets if they are active
    private bool CheckPelletCount()
    {
        foreach( Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }
        return false;
    }

    // Reset the Ghost multiplyer
    private void ResetGhostMulti() 
    {
        this.ghostMulti = 1;
    }

    // Starting Game
    private void StartingGame()
    {
        starting.Play();
        Debug.Log("READY!");
    }
}

