using UnityEngine;
using ScriptableObjectArchitecture;

	
/// <summary>
/// 
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Objects/Storage", fileName = "Storage")]
public class Storage : ScriptableObject
{
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private GameStateSO endState;
    [SerializeField] private GameStateSO editState;

    [Header("Broadcasting On")]
    [SerializeField] private StringGameEvent updateCounterUI;

    private int storageCount;
    private int currentStorage;


    public void AddStorageLocations()
    {
        //CleanStorageLocations();

        var storageLocations = FindObjectsOfType<StorageLocation>();

        storageCount = storageLocations.Length;
        currentStorage = 0;
        updateCounterUI?.Raise($"0 / {storageCount}");
    }

    public void StoreBox()
    {
        currentStorage++;

        updateCounterUI.Raise($"{currentStorage} / {storageCount}");

        TryToEndLevel();
    }

    public void RemoveBox()
    {
        currentStorage--;

        updateCounterUI.Raise($"{currentStorage} / {storageCount}");

        if (currentStorage < 0)
            currentStorage = 0;
    }

    private void TryToEndLevel()
    {
        if (currentStorage >= storageCount && gameManager.PreviousState != editState)
        {
            gameManager.SetGameState(endState);
        }
    }
}
