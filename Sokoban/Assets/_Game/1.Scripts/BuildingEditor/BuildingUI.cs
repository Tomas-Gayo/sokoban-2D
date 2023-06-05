using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;


public class BuildingUI : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private Image buildableIconUI;
	[SerializeField] private BuildableBase buildableObject;

    [Header("Broadcasting on")]
	[SerializeField] private BuildableRequestGameEvent onClickEvent;

    private void Start()
    {
        buildableIconUI.sprite = buildableObject.BuildableIcon;
    }

    public void ButtonClicked()
    {
		var request = new BuildableRequest(
			buildable: buildableObject
			);

		onClickEvent.Raise(request);
    }
}
