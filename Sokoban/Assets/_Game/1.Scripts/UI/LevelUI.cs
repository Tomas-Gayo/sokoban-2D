using UnityEngine;
using TMPro;


public class LevelUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI levelNameTxt;
	[SerializeField] private LevelLoaderConfig levelLoaderConfig;

	private LevelInfo levelInfo;

	public void DisplayLevel(LevelInfo level)
    {
		if (level != null)
        {
			levelNameTxt.text = level.levelName;
			levelInfo = level;
        }
    }

	public void SetLevelInfo()
    {
		levelLoaderConfig.LevelToLoad = levelInfo;
    }
}
