using UnityEngine;
using UnityEngine.Events;
	
/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "Spawner", menuName = "Scriptable Objects/Spawner")]
public class Spawner : ScriptableObject
{
	public event UnityAction SpawnEvent = delegate { };
	public event UnityAction CleanSpawnEvent = delegate { };

	public void SpawnObjectsInScene()
    {
		SpawnEvent.Invoke();
    }

	public void RemoveObjectsFromScene()
    {
		CleanSpawnEvent.Invoke();
    }
}
