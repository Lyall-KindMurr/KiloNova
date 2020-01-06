using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static bool[] weaponPicker = new bool[5];

    void Start()
    {
        weaponPicker[1] = true;
        weaponPicker[2] = false;
        weaponPicker[3] = false;
        weaponPicker[4] = false;
    }

    void Update()
    {
        //i have 4 weapons, for 4 combinations of weapons

        if (Input.GetAxis("left alt") == 1)
        {
            weaponPicker[1] = false;
            weaponPicker[2] = false;
            weaponPicker[3] = false;
            weaponPicker[4] = false;
            StartCoroutine(Wait(25));
            swapWeapon();
        }

        if (weaponPicker[1])
        {
            this.GetComponent<PlayerWeaponHelix>().enabled = true;
            this.GetComponent<Laser>().enabled = true;
            this.GetComponent<Grenade_Launcher>().enabled = false;
            this.GetComponent<Slasher>().enabled = false;
        }
        if (weaponPicker[2])
        {
            this.GetComponent<PlayerWeaponHelix>().enabled = false;
            this.GetComponent<Laser>().enabled = true;
            this.GetComponent<Grenade_Launcher>().enabled = true;
            this.GetComponent<Slasher>().enabled = false;
        }
        if (weaponPicker[3])
        {
            this.GetComponent<PlayerWeaponHelix>().enabled = false;
            this.GetComponent<Laser>().enabled = false;
            this.GetComponent<Grenade_Launcher>().enabled = true;
            this.GetComponent<Slasher>().enabled = true;
        }
        if (weaponPicker[4])
        {
            this.GetComponent<PlayerWeaponHelix>().enabled = true;
            this.GetComponent<Laser>().enabled = false;
            this.GetComponent<Grenade_Launcher>().enabled = false;
            this.GetComponent<Slasher>().enabled = true;
        }
    }

    IEnumerator Wait(int timeToWait)
    {

    }

    void swapWeapon()
    {
        if (weaponPicker[1] == true)
        { weaponPicker[1] = false;
            weaponPicker[2] = true;
        }
        else if (weaponPicker[2] == true)
        {
            weaponPicker[2] = false;
            weaponPicker[3] = true;
        }
        else if (weaponPicker[3] == true)
        {
            weaponPicker[3] = false;
            weaponPicker[4] = true;
        }
        else if (weaponPicker[4] == true)
        {
            weaponPicker[4] = false;
            weaponPicker[1] = true;
        }
    }

}
