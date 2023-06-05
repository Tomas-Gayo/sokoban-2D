using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// </summary>
//[CreateAssetMenu(fileName = "NewInpuReader", menuName = "Scriptable Objects/InpuReader")]
public class InputReader : ScriptableObject, PlayerInputs.IGameplayActions, PlayerInputs.IBuildEditorActions
{
    // Gameplay events
    public event UnityAction<Vector2> MoveEvent = delegate { };

    // Build Editor events
    public event UnityAction MouseLeftClickEvent = delegate { };
    public event UnityAction MouseRightClickEvent = delegate { };
    public event UnityAction<Vector2> MousePositionEvent = delegate { };

    private PlayerInputs playerInputs;

    private void OnEnable()
    {
        if (playerInputs == null)
        {
            playerInputs = new PlayerInputs();

            EnableBuildEditorControls();
            //EnableGameplayControls();

            playerInputs.Gameplay.SetCallbacks(this);
            playerInputs.BuildEditor.SetCallbacks(this);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>().normalized);
    }


    public void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            MouseLeftClickEvent.Invoke();
    }

    public void OnMouseRightClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            MouseRightClickEvent.Invoke();
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePositionEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void EnableGameplayControls()
    {
        playerInputs.Gameplay.Enable();
        playerInputs.BuildEditor.Disable();
    }

    public void EnableBuildEditorControls()
    {
        playerInputs.Gameplay.Disable();
        playerInputs.BuildEditor.Enable();
    }

    public void DisableAllInputs()
    {
        playerInputs.Gameplay.Disable();
        playerInputs.BuildEditor.Disable();
    }
}
