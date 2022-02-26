using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    [SerializeField, Header("Tile Set Up")]
    private GameObject cubePrefab;
    [SerializeField]
    private int dimentions;
    [SerializeField]
    private float distanceBetween = 4;

    [SerializeField, Header("Tile Type Management")]
    private int blockedOffMax = 10;


    private int[,] gridArray;
    List<CubeBehaviour> squares = new List<CubeBehaviour>();
    List<Vector2> goldOres = new List<Vector2>();
    List<Vector2> silverOres = new List<Vector2>();
    List<Vector2> bronzeOres = new List<Vector2>();

    void Start()
    {
        gridArray = new int[dimentions, dimentions];

        // Create the squares and set their value by chance
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // Instantiate square
                GameObject temp = Instantiate(cubePrefab);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.position = new Vector3(x * distanceBetween + (distanceBetween * dimentions / 8), 0, z * distanceBetween + (distanceBetween * dimentions / 8));
                squares.Add(temp.GetComponent<CubeBehaviour>());
            }
        }
    }
}
