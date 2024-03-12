using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ScenesManager", menuName = "SceneManagement/ScenesManager")]
public class ScenesManager : ScriptableObject
{
    public void LoadSceneAdditive(string sceneName) => SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    public void UnloadScene(string sceneName) => SceneManager.UnloadSceneAsync(sceneName);

    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void QuitGame() => Application.Quit();

}
