using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Components
    [SerializeField]
    private TileGrid tileGrid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        blockOffTimer += Time.deltaTime;

        if (blockOffTimer > timeForProgress)
        {
            blockOffTimer = 0;
            tileGrid.Progress(timeForProgress);
        }
    }
}
