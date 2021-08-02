using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    //variables declared on the begiining of the class
    [SerializeField] private int amountToIncrease;

    //Cached References
    [SerializeField] private AmmoType ammoType;

    private Ammo ammo;

    //method that is called on the first frame the class is brought in
    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    //method that detects trigger events
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.TAGS_PLAYER)
        {
            PickedUp();
        }
    }

    //increases ammo and destroys object
    private void PickedUp()
    {
        if(amountToIncrease < 0) { return; }
        ammo.IncreaseAmmo(amountToIncrease, ammoType);
        Destroy(gameObject);
    }
}
