using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //variables declared at the start
    [Header("Ammo Settings")]
    [SerializeField] AmmoSlot[] ammoSlots;

    //function for declared variables
    public int GetAmmoAmount(AmmoType ammoType)
    {
        int currentAmmo = GetAmmoSlot(ammoType).ammoAmount;
        return currentAmmo;
    }

    [System.Serializable]
    //private class that will hold the type of ammo
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    //reduces the amount of ammo
    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    //increases the amount of ammo
    public void IncreaseAmmo(int ammo, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammo;
    }

    //see what type of ammo we use
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot ammoSlot in ammoSlots)
        {
            if(ammoSlot.ammoType == ammoType)
            {
                return ammoSlot;
            }
        }
        return null;
    }
}
