using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update

    string sceneToLoad = "1";

    public void UpdateSceneToLoad(string new_text)
    {
        sceneToLoad = new_text;
        Debug.Log(sceneToLoad);
    }
    public void LoadScene()
    {
        string scene = "Level" + sceneToLoad;
        SceneManager.LoadScene(scene);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
