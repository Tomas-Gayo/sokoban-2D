using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

	
/// <summary>
/// 
/// </summary>
public class GridController : MonoBehaviour
{
    [Header("Dependencies")]
	[SerializeField] private InputReader inputReader;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GridSO gridSO;

    [Header("Level Configuration")]
    [SerializeField] private Tilemap previewMap;
    [SerializeField] private Transform levelParent;

    // References
    private Camera mainCamera;
    private BuildableBase currentBuildable;
    private Vector3 mousePosition;
    private Vector3Int currentGridPosition;
    private SpriteRenderer drawer;

    private BuildableBase CurrentBuildable
    {
        get { return currentBuildable; }
        set
        {
            currentBuildable = value;

            UpdateSelectedBuildablePreview();
        }
    }

    // ========== UNITY CALLBACKS ========== //
    private void Awake()
    {
        mainCamera = Camera.main;

        drawer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        gridSO.GenerateEditorGrid(mainCamera, levelParent);
    }

    private void OnEnable()
    {
        inputReader.MouseLeftClickEvent += OnMouseLeftClick;
        inputReader.MouseRightClickEvent += OnMouseRightClick;
        inputReader.MousePositionEvent += OnMousePosition;
    }

    private void OnDisable()
    {
        inputReader.MousePositionEvent -= OnMousePosition;
        inputReader.MouseRightClickEvent -= OnMouseRightClick;
        inputReader.MousePositionEvent -= OnMousePosition;
    }

    private void Update()
    {
        if (currentBuildable != null)
        {
            UpdateCurrentGridPosition();
        }
    }

    // ========== EDITOR LOGIC ========== //
    private void UpdateCurrentGridPosition()
    {
        Vector3 pos = mainCamera.ScreenToWorldPoint(mousePosition);
        Vector3Int newGridPosition = previewMap.WorldToCell(pos);

        if (newGridPosition != currentGridPosition)
        {
            currentGridPosition = newGridPosition;

            UpdateSelectedBuildablePreview();
        }
    }


    public void UpdateSelectedBuildablePreview()
    {
        if (currentBuildable != null)
        {
            drawer.sprite = CurrentBuildable.BuildableIcon;
            drawer.transform.position = currentGridPosition;
        } 
        else
        {
            drawer.sprite = null;
        }
        
        
    }

    private void DrawBuildable()
    {
        if (gridSO.GridObjects.ContainsKey(currentGridPosition))
        {
            gridSO.RemoveSlotObject(currentGridPosition);
            gridSO.DrawSlot(currentGridPosition, currentBuildable, levelParent);
        }
        else
        {
            // Send error message to the user
        }
    }

    // ========== INPUT EVENTS ========== //
    private void OnMouseLeftClick()
    {
        if (currentBuildable != null)
        {
            DrawBuildable();
        }
    }

    private void OnMouseRightClick()
    {
        CurrentBuildable = null;
    }

    private void OnMousePosition(Vector2 input)
    {
        mousePosition = input;
    }

    public void SetBuildableObject(BuildableRequest request)
    {
        CurrentBuildable = request.buildable;
    }
}
