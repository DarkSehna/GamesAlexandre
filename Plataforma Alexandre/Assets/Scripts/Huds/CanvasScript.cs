using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Player player;

    #region PlayerHud
    private int powerSet = 5;
    public Image[] powerImages;
    public Image[] ammo;
    private int selectedPower;
    private int previousAmmo;
    private int selectedPowerAmmo;
    private int selectedPowerMaxAmmo;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SwitchOff();
        AmmoOff();

        selectedPower = (int)player.inputHandler.currentPower; // Poder selecionado
        selectedPowerAmmo = player.playerData.ammo[selectedPower]; // Munição atual
        previousAmmo = selectedPower; // Munição anterior
        selectedPowerMaxAmmo = player.playerData.maxAmmo[selectedPower]; // Munição máxima
    }

    private void Update()
    {
        selectedPower = (int)player.inputHandler.currentPower;
        selectedPowerAmmo = player.playerData.ammo[selectedPower];
        selectedPowerMaxAmmo = player.playerData.maxAmmo[selectedPower];

        if (selectedPower != powerSet)
        {
            SwitchOff();
            AmmoOff();
            PowerSelected();
            powerImages[selectedPower].gameObject.SetActive(true);
            powerSet = selectedPower;
            previousAmmo = selectedPowerAmmo;
        }
        else if(selectedPowerAmmo != previousAmmo)
        {
            Debug.Log(selectedPowerAmmo);
            Debug.Log(previousAmmo);
            AmmoSpent(selectedPowerAmmo);
            previousAmmo = selectedPowerAmmo;
        }
    }

    private void SwitchOff()
    {
        for (int i = 0; i < powerImages.Length; i++)
        {
            powerImages[i].gameObject.SetActive(false);
        }
    }

    private void AmmoOff()
    {
        for (int i = 0; i < ammo.Length; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }
    }

    private void AmmoSpent(int shotBullet)
    {
        var ammoImage = ammo[shotBullet].GetComponent<Image>();
        ammoImage.color = Color.gray;
    }

    private void AmmoOn(int howMuchMaxAmmo, int howMuchLeftAmmo, Color color)
    {
        for (int i = 0; i < howMuchMaxAmmo; i++)
        {
            ammo[i].gameObject.SetActive(true);
            var ammoImages = ammo[i].GetComponent<Image>();
            ammoImages.color = Color.gray;
        }
        for (int i = 0; i < howMuchLeftAmmo; i++)
        {
            var ammoImages = ammo[i].GetComponent<Image>();
            ammoImages.color = color;
        }
    }

    private void PowerSelected()
    {
        if(selectedPower == 0)
        {
            AmmoOn(selectedPowerMaxAmmo, selectedPowerAmmo, Color.green);
        }
        else if(selectedPower == 1)
        {
            AmmoOn(selectedPowerMaxAmmo, selectedPowerAmmo, Color.yellow);
        }
        else if (selectedPower == 2)
        {
            AmmoOn(selectedPowerMaxAmmo, selectedPowerAmmo, Color.cyan);
        }
        else if (selectedPower == 3)
        {
            AmmoOn(selectedPowerMaxAmmo, selectedPowerAmmo, Color.red);
        }
        else if (selectedPower == 4)
        {
            AmmoOn(selectedPowerMaxAmmo, selectedPowerAmmo, Color.black);
        }
    }
}
