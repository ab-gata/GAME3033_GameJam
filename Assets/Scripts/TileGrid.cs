using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGrid : MonoBehaviour
{
    [SerializeField, Header("Tile Set Up")]
    private GameObject cubePrefab;
    [SerializeField]
    private int dimentions = 10;
    [SerializeField]
    private float distanceBetween = 3;

    [SerializeField, Header("Tile Type Management")]
    private int blockedOffMax = 60;


    private int[,] gridArray;
    List<CubeBehaviour> allCubes = new List<CubeBehaviour>();
    List<CubeBehaviour> emptyCubes = new List<CubeBehaviour>();
    List<CubeBehaviour> blockedOffCubes = new List<CubeBehaviour>();

    void Start()
    {
        gridArray = new int[dimentions, dimentions];
        int n = 0;

        // Create the squares and set their value by chance
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                // Instantiate square
                GameObject temp = Instantiate(cubePrefab);
                temp.transform.SetParent(gameObject.transform);
                temp.transform.position = new Vector3(x * distanceBetween + (distanceBetween * dimentions / 8), 0, z * distanceBetween + (distanceBetween * dimentions / 8));
                temp.GetComponent<CubeBehaviour>().Number = n;
                n++;
                allCubes.Add(temp.GetComponent<CubeBehaviour>());
            }
        }
        emptyCubes = allCubes;
    }

    public void Progress(float time)
    {
        SetBlockedOff(time);
    }

    private void SetBlockedOff(float time)
    {
        int rand = (int)Random.Range(0.0f, emptyCubes.Count);

        // Set blocked off
        emptyCubes[rand].BlockOff(time);

        // Remove from empty list and add to blocked off list
        blockedOffCubes.Add(emptyCubes[rand]);
        emptyCubes.RemoveAt(rand);
    }
}
