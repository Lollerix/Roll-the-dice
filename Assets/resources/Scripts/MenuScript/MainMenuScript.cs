using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewGame()
    {
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
