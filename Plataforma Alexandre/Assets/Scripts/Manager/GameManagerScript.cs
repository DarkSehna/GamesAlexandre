using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private static GameManagerScript gameManager;

    private void Start()
    {
        if(gameManager != null)
        {
            Destroy(this.gameObject);
            return;
        }
        gameManager = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
