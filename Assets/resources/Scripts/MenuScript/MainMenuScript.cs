using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void StartNewGame()
    {
        SceneManager.LoadScene("MainMap", LoadSceneMode.Single);
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
