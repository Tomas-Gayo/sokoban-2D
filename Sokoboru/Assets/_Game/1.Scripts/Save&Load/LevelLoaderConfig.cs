using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "LevelLoaderConfig", menuName = "Scriptable Objects/LevelLoaderConfig")]
public class LevelLoaderConfig : ScriptableObject
{
    [SerializeField] private LevelInfo levelToLoad;

    public LevelInfo LevelToLoad
    {
        get { return levelToLoad; }
        set { levelToLoad = value; }
    }
}
