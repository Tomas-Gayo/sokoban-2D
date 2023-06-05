using UnityEngine;
using System.Collections.Generic;

	
/// <summary>
/// 
/// </summary>
public class MenuLevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject levelUI;
    [SerializeField] private GameObject levelSelectorUI;

    public void DisplayLevels()
    {
        List<LevelInfo> data = FileHandler.ReadListFromJSON<LevelInfo>("Levels.json");

        foreach (LevelInfo level in data)
        {
            var temp = Instantiate(levelUI);
            temp.transform.SetParent(levelSelectorUI.transform, false);

            temp.gameObject.GetComponent<LevelUI>().DisplayLevel(level);
        }
    }

    public void CleanLevels()
    {
        var levels = levelSelectorUI.GetComponentsInChildren<LevelUI>();

        foreach (var level in levels)
        {
            Destroy(level.gameObject);
        }
    }
}
