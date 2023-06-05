using UnityEngine;

	
/// <summary>
/// 
/// </summary>
public class TopMenuButtonsHandler : MonoBehaviour
{
	[SerializeField] private Storage storage;
	[SerializeField] private Spawner spawner;


	public void OnTestButtonClicked()
    {
		spawner.SpawnObjectsInScene();
		storage.AddStorageLocations();
    }

	public void OnEditButtonClicked()
	{
		spawner.RemoveObjectsFromScene();
	}

	public void OnResetButtonClicked()
    {
		spawner.RemoveObjectsFromScene();
		spawner.SpawnObjectsInScene();
	}
}
