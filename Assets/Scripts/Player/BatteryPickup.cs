using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    //variables declared
    [SerializeField] private float batteryTimer = 15f;


    //when the object is picked up
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.TAGS_PLAYER)
        {
           other.gameObject.GetComponentInChildren<Flashlite>().AddTime(batteryTimer);
           Destroy(gameObject);
        }
    }
}
