using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    // public Player pacman;
    public PlayerController pacman;
    public Transform pellets;
    public Energizer energizer;

    public int ghostMulti { get; private set; }
    public int score { get; private set; }
    public int lives { get; private set; }

    // Start the Game
    private void Start()
    {
        NewGame();
    }

    // New Game run at the beginning and a restart
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        //NewRound();
    }

    // New Round, Set everything back and increase variables
    private void NewRound()
    {
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

    // If death, reset the player and ghosts, but keep pellets as the are.
    private void ResetState()
    {
        ResetGhostMulti();
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
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
        int points = ghost.points * this.ghostMulti;
        SetScore(this.score + points);
        this.ghostMulti++;
    }

    // Player gets eaten, reset board, and lose a life
    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0) {
            Invoke(nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }

    // Add to score if pellet is eaten, check to see if all have been eaten, if so new round begins
    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!CheckPelletCount())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    // If energizer gets eaten, increase score, turn ghosts to blue
    public void EnergizerEaten(Energizer energizer)
    {
        energizer.gameObject.SetActive(false);

        SetScore(this.score + energizer.points);

        // power up pacman
        // ghosts scared
    }

    // Check the pellets if they are active
    private bool CheckPelletCount()
    {
        foreach( Transform pellet in this.pellets)
        {
            //Debug.Log(pellet);
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    // Reset the ghost multiplyer
    private void ResetGhostMulti() 
    {
        this.ghostMulti = 1;
    }
}

