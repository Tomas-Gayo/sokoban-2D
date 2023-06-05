using UnityEngine;

	
/// <summary>
/// 
/// </summary>
public class SpawnSystem : MonoBehaviour
{
	[SerializeField] private Spawner spawner;

	[SerializeField] private GameObject boxPrefab;
	[SerializeField] private GameObject playerPrefab;

	[SerializeField] private GridSO gridSO;

	private GameObject[] boxSpawns;
	private GameObject[] playerSpawns;

    private void OnEnable()
    {
		spawner.SpawnEvent += BoxSpawner;
		spawner.SpawnEvent += PlayerSpawner;

        spawner.CleanSpawnEvent += CleanTestGrid;
    }

    private void OnDisable()
    {
		spawner.SpawnEvent -= BoxSpawner;
		spawner.SpawnEvent -= PlayerSpawner;


        spawner.CleanSpawnEvent -= CleanTestGrid;
    }

    private void BoxSpawner()
    {
		boxSpawns = GameObject.FindGameObjectsWithTag("BoxSpawn");

		foreach (var spawn in boxSpawns)
        {
			Instantiate(boxPrefab, spawn.transform.position, Quaternion.identity);
			gridSO.BlockSlot(Vector3Int.FloorToInt(spawn.transform.position));
        }
    }

	private void PlayerSpawner()
	{
		playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");

		foreach (var spawn in playerSpawns)
        {
			Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
        }
	}

    private void CleanTestGrid()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var box in boxes)
        {
            Destroy(box);
        }

        foreach (var player in players)
        {
            Destroy(player);
        }

        gridSO.CleanBlcokedGrid(); 
    }

    public void StartGameLevel()
    {
		BoxSpawner();
		PlayerSpawner();
    }
}
