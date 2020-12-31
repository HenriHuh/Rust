using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static List<Vector3> GetGrid(int size, float distanceBetween)
    {
        List<Vector3> grid = new List<Vector3>();
        for (int x = -size; x <= size; x++)
        {
            for (int y = -size; y <= size; y++)
            {
                grid.Add(new Vector3(x, y) * distanceBetween);
            }
        }
        return grid;
    }
}
