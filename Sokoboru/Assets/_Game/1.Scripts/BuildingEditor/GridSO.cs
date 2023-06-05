using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This script is responsible of the grid creation and slot drawing
/// </summary>
[CreateAssetMenu(fileName = "GridSO", menuName = "Scriptable Objects/GridSO")]
public class GridSO : ScriptableObject
{
    [SerializeField] private int height, width;
    [SerializeField] private BuildableBase defaultBuildable;

    private Dictionary<Vector3Int, GameObject> gridObjects;
    private Dictionary<Vector3Int, BuildableBase> staticGrid;
    private Dictionary<Vector3Int, bool> isBlocked;

    public int Height => height;
    public int Width => width;
    public Dictionary<Vector3Int, GameObject> GridObjects => gridObjects;
    public Dictionary<Vector3Int, BuildableBase> StaticGrid => staticGrid;
    public Dictionary<Vector3Int, bool> IsBlocked => isBlocked;

    public void InitGrid()
    {
        gridObjects = new Dictionary<Vector3Int, GameObject>();
        staticGrid = new Dictionary<Vector3Int, BuildableBase>();
        isBlocked = new Dictionary<Vector3Int, bool>();
    }

    public void GenerateEditorGrid(Camera cam, Transform levelParent)
    {
        // Init dictionaries
        InitGrid();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                DrawSlot(new Vector3Int(x, y), defaultBuildable, levelParent);
            }
        }

        // Center cam on grid
        ConfigCamera(cam, height, width);
    }

    public void ConfigCamera(Camera cam, float height, float width)
    {
        cam.transform.position = new Vector3(width / 2 - 0.5f, height / 2 - 0.5f, -10);
        cam.orthographicSize = Mathf.Min(width, height);
    }

    public void DrawSlot(Vector3Int currentSlot, BuildableBase buildable, Transform levelParent)
    {
        GameObject temp = Instantiate(buildable.BuildableObject, new Vector3Int(currentSlot.x, currentSlot.y), Quaternion.identity);
        temp.transform.parent = levelParent;
        gridObjects[currentSlot] = temp;

        staticGrid[currentSlot] = buildable;
        isBlocked[currentSlot] = false;
    }

    public void RemoveSlotObject(Vector3Int previousSlot)
    {
        if (gridObjects[previousSlot] != null)
        {
            Destroy(gridObjects[previousSlot]);
        }
    }

    public void CleanBlcokedGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                UnblockSlot(new Vector3Int(x, y));
            }
        }
    }

    public void UnblockSlot(Vector3Int position)
    {
        IsBlocked[position] = false;
    }

    public void BlockSlot(Vector3Int position)
    {
        IsBlocked[position] = true;
    }

    public bool IsAccessible(Vector3Int nextPosition)
    {
        return StaticGrid[nextPosition].IsAccessible && !IsBlocked[nextPosition];

    }    
}
