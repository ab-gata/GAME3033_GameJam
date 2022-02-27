using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Counters for progress
    private int round = 0;
    private float timer = 0;
    private float blockOffTimer = 0;
    [SerializeField]
    private float timeForProgress = 3.0f;

    // Player stats
    private float score = 0;
    private int pickUps = 0;
    private int tileRestores = 0;
    private int lives = 3;

    // Components
    [SerializeField]
    private TileGrid tileGrid;
    [SerializeField]
    private GameObject pickUpObject;

    // HUD references
    [SerializeField] 
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI pickUpsText;
    [SerializeField]
    TextMeshProUGUI tileRestoreText;
    [SerializeField]
    TextMeshProUGUI livesText;
    [SerializeField]
    TextMeshProUGUI infoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        // Spawn another pick up
        if (true)
        {

        }

        UpdateHUD();
    }

    private void UpdateHUD()
    {
        scoreText.text = "[score] " + score;
        timerText.text = "[timer] " + (int)timer;
        pickUpsText.text = "[restore fragments] " + pickUps + "/3";
        tileRestoreText.text = "[tile restores] " + tileRestores;
        livesText.text = "[lives] " + lives;
    }

    // When a pick up is collect, spawn another one
    public void AddPickUp()
    {
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
            tileRestores--;
            return true;
        }
        return false;
    }

    public void LoseLives()
    {
        lives--;
        if (lives <= 0)
        {
            // GAME OVER
        }
    }
}
