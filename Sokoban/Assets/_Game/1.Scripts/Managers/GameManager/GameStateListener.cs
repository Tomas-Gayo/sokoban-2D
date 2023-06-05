using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;
using System.Collections.Generic;

public class GameStateListener : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    [Header("Listening to Events")]
    public GameStateSOGameEvent gameStateChangedEvent;

    [Header("Actions")]
    public UnityEvent onMainMenuState = default;
    public UnityEvent onGameState = default;
    public UnityEvent onLoadingState = default;
    public UnityEvent onEditState = default;
    public UnityEvent onTestLevel = default;
    public UnityEvent onEndGameState = default;
    public UnityEvent onSaveState = default;


    private void OnEnable()
    {
        gameStateChangedEvent.AddListener(GameStateChanged);
    }

    private void OnDisable()
    {
        gameStateChangedEvent.RemoveListener(GameStateChanged);
    }


    private void GameStateChanged(GameStateSO newGameState)
    {
        switch (newGameState.name)
        {
            case "MainMenu":
                onMainMenuState.Invoke();
                inputReader.DisableAllInputs();
                break;
            case "InGame":
                onGameState.Invoke();
                inputReader.EnableGameplayControls();
                break;
            case "Edit":
                onEditState.Invoke();
                inputReader.EnableBuildEditorControls();
                break;
            case "TestLevel":
                onTestLevel.Invoke();
                inputReader.EnableGameplayControls();
                break;
            case "EndGame":
                onEndGameState.Invoke();
                inputReader.DisableAllInputs();
                break;
            case "Loading":
                onLoadingState.Invoke();
                inputReader.DisableAllInputs();
                break;
            case "Save":
                onSaveState.Invoke();
                inputReader.DisableAllInputs();
                break;
            default:
                Debug.LogError("State not recognized");
                break;
        }
    }
}
