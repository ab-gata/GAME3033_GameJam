using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Colours to show cube states
    [SerializeField]
    private Material blockedOffMaterial;
    [SerializeField]
    private Material goingToBlockOffMaterial;
    [SerializeField]
    private Material normalMaterial;

    // Pick up spawning
    [SerializeField]
    private Transform pickUpSpawnTransform;
    public Transform PickUpTransform { get { return pickUpSpawnTransform; } }


    // Cube stats
    private int number;
    public int Number { set { number = value; } }
    private bool blockedOff = false;
    private bool transitioning = false;
    private float timer = 0.0f;
    private float countdown = 0.0f;

    // Refernces
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockedOff && transitioning)
        {
            timer += Time.deltaTime;
            if (timer > countdown)
            {
                GetComponent<MeshRenderer>().material = blockedOffMaterial;
                blockedOff = true;
                transitioning = false;
                timer = 0.0f;
            }
        }
    }

    public void BlockOff(float time)
    {
        GetComponent<MeshRenderer>().material = goingToBlockOffMaterial;
        transitioning = true;
        countdown = time;
    }

    public void UnblockOff()
    {
        blockedOff = false;
        GetComponent<MeshRenderer>().material = normalMaterial;
    }

    // On collision, restore block is tile restore availble, otherwise lose life
    private void OnCollisionEnter(Collision collision)
    {
        if (blockedOff)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (gameManager.TryTileRestore())
                {
                    UnblockOff();
                }
                else
                {
                    gameManager.LoseLives();
                }
            }
        }
    }
}
