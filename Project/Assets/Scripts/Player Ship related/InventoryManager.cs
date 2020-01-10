using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public float swapTime;

    private float waitingLeft;
    private int selectedWeapon = 0;

    private void Update()
    {
        if(Input.GetButtonDown("Fire3") == true)
        {
            if (selectedWeapon == 3)
            {
                selectedWeapon = 0;
            }
            else
            { selectedWeapon++; }

            waitingLeft = swapTime;
            Debug.Log("set waitingleft to swaptime");
        }
        //if you still have to wait, tick down
        if(waitingLeft > 0)
        {
            waitingLeft--;
            Debug.Log("waiting for X more frames :" + waitingLeft);
            this.GetComponent<Slasher>().enabled = false;
            this.GetComponent<PlayerWeaponHelix>().enabled = false;
            this.GetComponent<Laser>().enabled = false;
            this.GetComponent<Grenade_Launcher>().enabled = false;
        }
        //you waited the time, and this happens every frame.
        else
        {
            if(selectedWeapon == 0)
            {
                this.GetComponent<PlayerWeaponHelix>().enabled = true;
            }
            else if (selectedWeapon == 1)
            {
                this.GetComponent<Laser>().enabled = true;
            }
            else if (selectedWeapon == 2)
            {
                this.GetComponent<Grenade_Launcher>().enabled = true;
            }
            else if (selectedWeapon == 3)
            {
                this.GetComponent<Slasher>().enabled = true;
            }
        }
    }

    /*
    void Start()
    {
        weaponPicker[1] = true;
        weaponPicker[2] = false;
        weaponPicker[3] = false;
        weaponPicker[4] = false;
    }

    void Update()
    {
        

        if (Input.GetKeyDown("left alt") == true)
        {
            weaponPicker[1] = false;
            weaponPicker[2] = false;
            weaponPicker[3] = false;
            weaponPicker[4] = false;

            this.GetComponent<PlayerWeaponHelix>().enabled = false;
            this.GetComponent<Laser>().enabled = false;
            this.GetComponent<Grenade_Launcher>().enabled = false;
            this.GetComponent<Slasher>().enabled = false;

            waitingLeft = swapTime;            
        }


        if (waitingLeft >= 0)
        {
            waitingLeft--;
            Debug.Log("waiting for frames:" + waitingLeft);
        }
        else
        {
            if (weaponPicker[1])
            {
                this.GetComponent<PlayerWeaponHelix>().enabled = true;
                this.GetComponent<Laser>().enabled = false;
                this.GetComponent<Grenade_Launcher>().enabled = false;
                this.GetComponent<Slasher>().enabled = false;
            }
            else if (weaponPicker[2])
            {
                this.GetComponent<PlayerWeaponHelix>().enabled = false;
                this.GetComponent<Laser>().enabled = true;
                this.GetComponent<Grenade_Launcher>().enabled = false;
                this.GetComponent<Slasher>().enabled = false;
            }
            else if (weaponPicker[3])
            {
                this.GetComponent<PlayerWeaponHelix>().enabled = false;
                this.GetComponent<Laser>().enabled = false;
                this.GetComponent<Grenade_Launcher>().enabled = true;
                this.GetComponent<Slasher>().enabled = false;
            }
            else if (weaponPicker[4])
            {
                this.GetComponent<PlayerWeaponHelix>().enabled = false;
                this.GetComponent<Laser>().enabled = false;
                this.GetComponent<Grenade_Launcher>().enabled = false;
                this.GetComponent<Slasher>().enabled = true;
            }
        }
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
    */
}
