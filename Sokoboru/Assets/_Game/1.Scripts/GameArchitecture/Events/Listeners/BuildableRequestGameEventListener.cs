using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "BuildableRequest")]
	public sealed class BuildableRequestGameEventListener : BaseGameEventListener<BuildableRequest, BuildableRequestGameEvent, BuildableRequestUnityEvent>
	{
	}
}