using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour
{
    public void OpenDoors(GameObject[] doors)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(false);
        }
    }

    public void CloseDoors(GameObject[] doors)
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].SetActive(true);
        }
    }
}
