using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCycler : MonoBehaviour
{
    //variables declared for the start of the game
    private int currentWeapon = 0;

    //method that is called at the first frame
    private void Start()
    {
        ToggleWeapons();
    }

    //method that gets called every frame
    private void Update()
    {
        ProcessWeaponCycles();
    }

    //method that looks which weapon is active via keyboard or mouse scrolling
    private void ProcessWeaponCycles()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyboardCycles();
        ProcessScrollCycles();

        if(previousWeapon != currentWeapon)
        {
            ToggleWeapons();
        }
    }

    //method that loops through the weapons and togggles them active or inactive
    private void ToggleWeapons()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    //method that cycles through weapons via keybord
    private void ProcessKeyboardCycles()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }

    }

    //method that cycles through weapons via scroll mouse button
    private void ProcessScrollCycles()
    {
        if(Input.GetAxis(Tags.MOUS_SCROLL_WHEEL) > 0)
        {
            ProcessMouseScrollUp();
        }

        if(Input.GetAxis(Tags.MOUS_SCROLL_WHEEL) < 0)
        {
            ProcessMouseScrollDown();
        }
    }

    //sets the values of the next weapon via scroll mouse
    private void ProcessMouseScrollUp()
    {
        if (currentWeapon >= transform.childCount - 1)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
    }

    //sets the values of the next weapon via scroll mouse
    private void ProcessMouseScrollDown()
    {
        if (currentWeapon <= 0)
        {
            currentWeapon = transform.childCount - 1;
        }
        else
        {
            currentWeapon--;
        }
    }
}
