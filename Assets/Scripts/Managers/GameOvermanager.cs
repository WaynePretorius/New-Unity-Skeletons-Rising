using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvermanager : MonoBehaviour
{
    //restarts the level and set the time back on
    public void Restart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }

    //quits the application
    public void TimeToExit()
    {
        Application.Quit();
    }
}
