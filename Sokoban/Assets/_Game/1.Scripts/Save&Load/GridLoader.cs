using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

	
/// <summary>
/// 
/// </summary>
public class GridLoader : MonoBehaviour
{
    [SerializeField] private GridSO gridS0;
    [SerializeField] private Storage storage;
    [SerializeField] private LevelLoaderConfig levelLoader;
    [SerializeField] private BuildableBase[] buildables;
    [SerializeField] private Transform levelParent;

    [Header("Broadcasting On")]
    [SerializeField] private StringGameEvent updateLevelNameUI;

    private LevelInfo currentLevel;
    private List<BuildableInfo> currentGrid;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void LoadGrid()
    {
        CleanGrid();

        currentLevel = levelLoader.LevelToLoad;
        currentGrid = currentLevel.grid;

        gridS0.InitGrid();

        for (int i = 0; i < currentGrid.Count; i++)
        {
            if (currentGrid[i].id != 0)
                gridS0.DrawSlot(currentGrid[i].position, AssignBuildable(currentGrid[i].id), levelParent);
        }

        gridS0.ConfigCamera(cam, currentLevel.height, currentLevel.width);
        updateLevelNameUI?.Raise(currentLevel.levelName);
        storage.AddStorageLocations();
    }

    private void CleanGrid()
    {
        if (currentGrid != null)
        {
            for (int i = 0; i < currentGrid.Count; i++)
            {
                gridS0.RemoveSlotObject(currentGrid[i].position);
            }
        }
    }

    private BuildableBase AssignBuildable(int id)
    {
        BuildableBase buildable = null;
        bool isFound = false;
        int i = 0;
        while (!isFound)
        {
            if (buildables[i].ID == id)
            {
                isFound = true;
                buildable = buildables[i];
            }
            i++;
        }
        return buildable;
    }
}
