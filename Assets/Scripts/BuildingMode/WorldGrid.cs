using System.Collections;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    [Header("World Grid Options")]
    public int defaultCellSize = 2;
    public int gridSizeX = 10;
    public int gridSizeY = 10;

    public Vector3 gridOrigin;
    public bool enableDebug;

    #region Private Properties

    private WorldGridCell[,] __worldGrid;

    #endregion

    private void Awake()
    {
        GenerateWorldGrid(gridSizeX, gridSizeY, gridOrigin);
    }

    public void GenerateWorldGrid(int sizeX, int sizeY, Vector3 startPos)
    {
        __worldGrid = new WorldGridCell[sizeX, sizeY];

        Vector3 currentPos = startPos;

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                Debug.DrawLine(currentPos, new Vector3(currentPos.x, 0f, currentPos.z + defaultCellSize), Color.green, 1000f);
                Debug.DrawLine(currentPos, new Vector3(currentPos.x + defaultCellSize, 0f, currentPos.z), Color.green, 1000f);

                __worldGrid[i, j] = new WorldGridCell(defaultCellSize, currentPos);
                currentPos = new Vector3(currentPos.x, 0f, currentPos.z + defaultCellSize);

                
            }
            Debug.DrawLine(currentPos, new Vector3(currentPos.x + defaultCellSize, 0f, currentPos.z), Color.green, 1000f);

            currentPos = new Vector3(currentPos.x + defaultCellSize, 0f, startPos.z);
        }

        Debug.DrawLine(currentPos, new Vector3(currentPos.x, 0f, startPos.z + currentPos.z), Color.green, 1000f);
    }
}
