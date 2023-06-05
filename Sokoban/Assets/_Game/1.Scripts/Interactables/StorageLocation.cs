using UnityEngine;

	
/// <summary>
/// 
/// </summary>
public class StorageLocation : MonoBehaviour
{
    [SerializeField] private Storage storage;

    private bool isStored = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && !isStored)
        {
            storage.StoreBox();
            isStored = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") && isStored)
        {
            storage.RemoveBox();
            isStored = false;
        }
    }
}
