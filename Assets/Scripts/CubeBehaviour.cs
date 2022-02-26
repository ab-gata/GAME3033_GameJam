using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Colours to show cube states
    [SerializeField]
    private Material blockedOffMaterial;

    // Pick up spawning
    [SerializeField]
    private GameObject pickUpPrefab;
    [SerializeField]
    private Transform pickUpSpawnTransform;


    // Give the square a number
    private int number;
    public int Number { set { number = value; } }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockOff()
    {
        GetComponent<MeshRenderer>().material = blockedOffMaterial;
    }
}
