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

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        //NewRound();
    }

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

    private void ResetState()
    {
        ResetGhostMulti();
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        int points = ghost.points * this.ghostMulti;
        SetScore(this.score + points);
        this.ghostMulti++;
    }

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

    public void EnergizerEaten(Energizer energizer)
    {
        energizer.gameObject.SetActive(false);

        SetScore(this.score + energizer.points);

        // power up pacman
        // ghosts scared
    }

    private bool CheckPelletCount()
    {
        foreach( Transform pellet in this.pellets)
        {
            Debug.Log(pellet);
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }


    private void ResetGhostMulti() 
    {
        this.ghostMulti = 1;
    }
}

