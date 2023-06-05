using System;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

	
/// <summary>
/// 
/// </summary>
public class Saver : MonoBehaviour
{
	[SerializeField] private GridSO grid;

	public void SaveLevel(string levelName) 
    { 
        List<LevelInfo> currentLevels = FileHandler.ReadListFromJSON<LevelInfo>("Levels.json");

        List<BuildableInfo> buildablesData = new List<BuildableInfo>();

        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                BuildableBase buildable = grid.StaticGrid[pos];

                if (buildable != null)
                {
                    BuildableInfo b = new BuildableInfo(pos, buildable.ID);
                    buildablesData.Add(b);
                }
            }
        }
        int height = grid.Height;
        int width = grid.Width;
        LevelInfo newLevel = new LevelInfo(levelName, height, width, buildablesData);
        currentLevels.Add(newLevel);

        FileHandler.SaveToJSON<LevelInfo>(currentLevels, "Levels.json");
    }
}

[Serializable]
public class LevelInfo
{
    public string levelName;
    public int height;
    public int width;
    public List<BuildableInfo> grid;

    public LevelInfo(string levelName, int height, int width, List<BuildableInfo> buildables)
    {
        this.levelName = levelName;
        this.height = height;
        this.width = width;
        grid = buildables;
    }
}
[Serializable]
public class BuildableInfo
{
    public int id;
    public Vector3Int position;

    public BuildableInfo(Vector3Int position, int buildableID)
    {
        id = buildableID;
        this.position = position;
    }
}