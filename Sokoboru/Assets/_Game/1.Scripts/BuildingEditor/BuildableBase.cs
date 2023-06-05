using UnityEngine;

[CreateAssetMenu(fileName = "Buildable", menuName = "Scriptable Objects/BuildingObjects/Buildable")]
public class BuildableBase : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Sprite buildableIcon;
    [SerializeField] private GameObject buildableObject;
    [SerializeField] private bool isAccessible;

    public int ID => id;
    public Sprite BuildableIcon => buildableIcon;
    public GameObject BuildableObject => buildableObject;
    public bool IsAccessible => isAccessible;

}
