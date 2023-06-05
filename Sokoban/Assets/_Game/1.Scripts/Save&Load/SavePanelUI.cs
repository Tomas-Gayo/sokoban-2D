using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

	
/// <summary>
/// 
/// </summary>
public class SavePanelUI : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI levelNameTxt;

	[Header("Broadcasting on")]
	[SerializeField] private StringGameEvent saveLevelEvent;

	public void Save()
    {
		if (levelNameTxt.text == null)
        {
			saveLevelEvent.Raise("LevelNotDefined");
        }

		saveLevelEvent.Raise(levelNameTxt.text);
    }
}
