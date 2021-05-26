using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Public Variables
    public GameObject pauseMenu;
    public bool gameIsPaused;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (gameIsPaused)
            {
                Unpause();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Pause()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        /*var musica = jogador.GetComponent<AudioSource>();
        musica.Pause();*/

    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
