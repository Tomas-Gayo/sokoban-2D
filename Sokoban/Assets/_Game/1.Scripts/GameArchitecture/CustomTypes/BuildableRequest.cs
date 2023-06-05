/// <summary>
/// 
/// </summary>
[System.Serializable]
public class BuildableRequest
{
    public BuildableBase buildable;
    public BuildableRequest(BuildableBase buildable)
    {
        this.buildable = buildable;
    }
}