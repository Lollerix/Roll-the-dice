using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Texture2D cursorSword;

    public void StartNewGame()
    {
        UnityEngine.Cursor.SetCursor(cursorSword, Vector2.zero, CursorMode.Auto);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Option()
    {
        gameObject.SetActive(false);
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
    }
}
