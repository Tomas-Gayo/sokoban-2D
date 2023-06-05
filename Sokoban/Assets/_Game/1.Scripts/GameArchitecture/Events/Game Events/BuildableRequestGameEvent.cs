using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "BuildableRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Buildable",
	    order = 120)]
	public sealed class BuildableRequestGameEvent : GameEventBase<BuildableRequest>
	{
	}
}