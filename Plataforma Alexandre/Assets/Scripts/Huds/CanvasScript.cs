using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public PlayerInputHandler inputHandler;

    #region PlayerHud
    private int powerSet = -1;
    public Image[] powerImages;
    #endregion

    private void Start()
    {
        SwitchOff();
    }

    private void Update()
    {
        if((int)inputHandler.currentPower != powerSet)
        {
            SwitchOff();
            powerImages[(int)inputHandler.currentPower].gameObject.SetActive(true);
            powerSet = (int)inputHandler.currentPower;
        }
    }

    private void SwitchOff()
    {
        for (int i = 0; i < powerImages.Length; i++)
        {
            powerImages[i].gameObject.SetActive(false);
        }
    }
}
