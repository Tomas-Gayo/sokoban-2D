using UnityEngine;
using TMPro;
	
/// <summary>
/// 
/// </summary>
public class InGameMenuHandler : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI levelNameTxt;
	[SerializeField] private TextMeshProUGUI levelStorageTxt;

	public void FillLevelNameText(string levelName)
    {
		levelNameTxt.text = levelName;
    }

	public void FillLevelStorageText(string storage)
    {
		levelStorageTxt.text = $"{storage}";
    }
}
