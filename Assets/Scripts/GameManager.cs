using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Counters for progress
    private int roundUp = 10;
    private float timer = 0;
    private float blockOffTimer = 0;
    [SerializeField]
    private float timeForProgress = 5.0f;

    // Player stats
    private float score = 0;
    private int pickUps = 0;
    private int tileRestores = 0;
    private int lives = 3;
    private bool pause = false;
    private int tilesRestored = 0;

    // Components
    [SerializeField]
    private TileGrid tileGrid;
    [SerializeField]
    private GameObject pickUpObject;

    // HUD references
    [SerializeField, Header("UI Elements")]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI tileRestoreText;
    [SerializeField]
    TextMeshProUGUI livesText;
    [SerializeField]
    TextMeshProUGUI infoText;

    [SerializeField, Header("GameOver Elements")]
    private GameObject gameoverHUD;
    [SerializeField]
    private TextMeshProUGUI gameoverScoreText;
    [SerializeField]
    private TextMeshProUGUI tilesRestoredScoreText;

    [SerializeField, Header("Pause HUD")]
    private GameObject pauseHUD;

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            // update timers
            timer += Time.deltaTime;
            blockOffTimer += Time.deltaTime;

            // Block off another block
            if (blockOffTimer > timeForProgress)
            {
                blockOffTimer = 0;
                tileGrid.Progress(timeForProgress);
            }

            // Update game difficulty based off time
            if (timer > roundUp)
            {
                roundUp += 10;
                if (timeForProgress > 2.0f)
                {
                    timeForProgress -= 0.5f;
                }
            }

            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        scoreText.text = "[score] " + score;
        timerText.text = "[timer] " + (int)timer;
        tileRestoreText.text = "[tile restores]\n" + tileRestores + " (" + pickUps + "/3)";
        livesText.text = "[lives] " + lives;
        infoText.text = "[tile block off speed]\n" + timeForProgress;
    }

    // When a pick up is collect, spawn another one
    public void AddPickUp()
    {
        score += 100;
        pickUps++;
        if (pickUps >= 3)
        {
            pickUps = 0;
            tileRestores++;
        }
        pickUpObject.transform.position = tileGrid.GetPickUpSpawnPos().position;
    }

    public bool TryTileRestore()
    {
        if (tileRestores >0)
        {
            score += 1000;
            tileRestores--;
            tilesRestored++;
            return true;
        }
        return false;
    }

    public void LoseLives()
    {
        lives--;
        if (lives <= 0)
        {
            pause = true;
            gameoverScoreText.text = "SCORE\n" + score;
            tilesRestoredScoreText.text = "TILES RESTORED\n" + tilesRestored;
            gameoverHUD.SetActive(true);
        }
        
    }

    public void Pause()
    {
        pause = true;
        pauseHUD.SetActive(true);
    }

    public void Resume()
    {
        pause = false;
        pauseHUD.SetActive(false);
    }

    public bool GamePaused()
    {
        return pause;
    }
}
