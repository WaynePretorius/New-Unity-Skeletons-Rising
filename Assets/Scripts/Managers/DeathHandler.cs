using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    //cached References
    private GameOvermanager manager;

    //function called on the first frame of the game
    private void Start()
    {
        manager = FindObjectOfType<GameOvermanager>();
        manager.gameObject.SetActive(false);
    }

    //handle what will happen as soon as the player dies
    public void DeathScreen()
    {
        manager.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
