using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

	
/// <summary>
/// This will prepare the scene doing whatever is requested
/// moreover persistant scenes are loaded
/// </summary>
public class SceneInitializer : MonoBehaviour
{
    [Header("Dependencies")]
	public SceneSO[] scenesToLoad;

    [Header("Events")]
	public UnityEvent onSceneReady;

    private void Start()
    {
        StartCoroutine(LoadDependencies());
    }

    private IEnumerator LoadDependencies()
    {
        foreach (SceneSO sceneToLoad in scenesToLoad)
        {
            if (!SceneManager.GetSceneByName(sceneToLoad.name).isLoaded)
            {
                AsyncOperation loadingOP = 
                    SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Additive);

                while (!loadingOP.isDone)
                    yield return null;
            }
        }

        onSceneReady?.Invoke();
    }
}
