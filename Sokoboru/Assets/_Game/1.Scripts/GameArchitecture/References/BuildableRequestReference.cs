using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class BuildableRequestReference : BaseReference<BuildableRequest, BuildableRequestVariable>
	{
	    public BuildableRequestReference() : base() { }
	    public BuildableRequestReference(BuildableRequest value) : base(value) { }
	}
}