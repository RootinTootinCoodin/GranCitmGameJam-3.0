using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win()
    {
        if (!finished)
        {
            winMenu.SetActive(true);
            finished = true;
            StartCoroutine(loadNextScene());
        }
    }

    public void Lose()
    {
        if (!finished)
        {
            loseMenu.SetActive(true);
            finished = true;
            StartCoroutine(loadCurrentScene());
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public IEnumerator loadNextScene()
    {
        yield return new WaitForSeconds(3.0f);

        nextScene();
    }

    public IEnumerator loadCurrentScene()
    {
        yield return new WaitForSeconds(3.0f);

        reloadScene();
    }
}
