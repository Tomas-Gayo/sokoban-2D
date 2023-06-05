using UnityEngine;

	
/// <summary>
/// 
/// </summary>
public class Box : MonoBehaviour
{
    [SerializeField] private Transform upPosition;
    [SerializeField] private Transform lowPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private Transform leftPosition;

    [SerializeField] private GridSO gridSO;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject;
            Vector3 direction  = player.GetComponent<PlayerController>().Direction;
            
            if (gridSO.IsAccessible(NextPosition(direction)))
            {
                MoveTo(NextPosition(direction));
            }
        }
    }

    private void MoveTo(Vector3Int nextPosition)
    {
        gridSO.UnblockSlot(Vector3Int.FloorToInt(transform.position));

        transform.position = nextPosition;

        gridSO.BlockSlot(nextPosition);
    }

    private Vector3Int NextPosition(Vector3 direction)
    {
        Vector3 nextPosition = Vector3.zero;

        if (direction.x == 1)
        {
            nextPosition = transform.localPosition + rightPosition.transform.localPosition;
        }
        else if (direction.x == -1)
        {
            nextPosition = transform.localPosition + leftPosition.transform.localPosition;
        }
        else if (direction.y == 1)
        {
            nextPosition = transform.localPosition + upPosition.transform.localPosition;
        }
        else if (direction.y == -1)
        {
            nextPosition = transform.localPosition + lowPosition.transform.localPosition;
        }

        return Vector3Int.FloorToInt(nextPosition);
    }
}
