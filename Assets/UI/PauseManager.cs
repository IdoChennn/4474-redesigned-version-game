using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject inGameUIObject;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseObject != null)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Time.timeScale = 0;
                    pauseObject.SetActive(true);
                    inGameUIObject.SetActive(false);
                    isPaused = true;
                }
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(false);
        inGameUIObject.SetActive(true);
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }
}
