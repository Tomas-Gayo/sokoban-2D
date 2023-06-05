using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class BuildableRequestEvent : UnityEvent<BuildableRequest> { }

	[CreateAssetMenu(
	    fileName = "BuildableRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Buildable",
	    order = 120)]
	public class BuildableRequestVariable : BaseVariable<BuildableRequest, BuildableRequestEvent>
	{
	}
}