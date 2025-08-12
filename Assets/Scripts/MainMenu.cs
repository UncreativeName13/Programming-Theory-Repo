using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

# if UNITY_EDITOR
using UnityEditor;
# endif

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int gameSceneIndex;

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
