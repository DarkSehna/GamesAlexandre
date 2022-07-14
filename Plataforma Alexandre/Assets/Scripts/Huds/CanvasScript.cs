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
    public Image[] ammoImages;
    private int selectedPower;
    private int[] previousAmmo;
    private int[] ammo;
    private int[] maxAmmo;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SwitchOff();
        AmmoOff();

        selectedPower = (int)player.inputHandler.currentPower; // Poder selecionado
        
        for (int i = 0; i < player.playerData.maxAmmo.Length; i++)
        {
            previousAmmo[i] = player.playerData.maxAmmo[i];
        }
        AmmoUpdate();
    }

    private void Update()
    {
        selectedPower = (int)player.inputHandler.currentPower;
        AmmoUpdate();

        if (selectedPower != powerSet)
        {
            SwitchOff();
            AmmoOff();
            PowerSelected();
            powerImages[selectedPower].gameObject.SetActive(true);
            powerSet = selectedPower;
            previousAmmo[selectedPower] = ammo[selectedPower];
        }
        else if(ammo[selectedPower] != previousAmmo[selectedPower])
        {
            Debug.Log(ammo[selectedPower]);
            Debug.Log(previousAmmo[selectedPower]);
            AmmoSpent(ammo[selectedPower]);
            previousAmmo[selectedPower] = ammo[selectedPower];
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
        for (int i = 0; i < ammoImages.Length; i++)
        {
            ammoImages[i].gameObject.SetActive(false);
        }
    }

    private void AmmoSpent(int shotBullet)
    {
        var ammoImage = ammoImages[shotBullet].GetComponent<Image>();
        ammoImage.color = Color.gray;
    }

    private void AmmoOn(int howMuchMaxAmmo, int howMuchLeftAmmo, Color color)
    {
        for (int i = 0; i < howMuchMaxAmmo; i++)
        {
            this.ammoImages[i].gameObject.SetActive(true);
            var ammoImages = this.ammoImages[i].GetComponent<Image>();
            ammoImages.color = Color.gray;
        }
        for (int i = 0; i < howMuchLeftAmmo; i++)
        {
            var ammoImages = this.ammoImages[i].GetComponent<Image>();
            ammoImages.color = color;
        }
    }

    private void AmmoUpdate()
    {
        for (int i = 0; i < player.playerData.ammo.Length; i++)
        {
            ammo[i] = player.playerData.ammo[i];
        }

        for (int i = 0; i < player.playerData.maxAmmo.Length; i++)
        {
            maxAmmo[i] = player.playerData.maxAmmo[i];
        }
    }

    private void PowerSelected()
    {
        if(selectedPower == 0)
        {
            AmmoOn(maxAmmo[selectedPower], ammo[selectedPower], Color.green);
        }
        else if(selectedPower == 1)
        {
            AmmoOn(maxAmmo[selectedPower], ammo[selectedPower], Color.yellow);
        }
        else if (selectedPower == 2)
        {
            AmmoOn(maxAmmo[selectedPower], ammo[selectedPower], Color.cyan);
        }
        else if (selectedPower == 3)
        {
            AmmoOn(maxAmmo[selectedPower], ammo[selectedPower], Color.red);
        }
        else if (selectedPower == 4)
        {
            AmmoOn(maxAmmo[selectedPower], ammo[selectedPower], Color.black);
        }
    }
}
