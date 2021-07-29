using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //variables declared at the start
    [Header("Ammo Settings")]
    [SerializeField] private int ammoAmount = 8;
    [SerializeField] AmmoSlot[] ammoslot;

    //function for declared variables
    public int AmmouAmount
    {
        get { return ammoAmount; }
    }

    [System.Serializable]
    //private class that will hold the type of ammo
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    //reduces the amount of ammo
    public void ReduceAmmo()
    {
        ammoAmount--;
    }

    //increases the amount of ammo
    public void IncreaseAmmo(int ammo)
    {
        ammoAmount += ammo;
    }
}
