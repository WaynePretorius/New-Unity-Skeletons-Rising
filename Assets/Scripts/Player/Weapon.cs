using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //variables for the weapon
    [Header("Weapon Settings")]
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 25f;

    //referenced caches
    [SerializeField] private Camera FPSCamera;
    [SerializeField] private ParticleSystem fireGun;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private Transform fxParent;

     // Update is called once per frame
    void Update()
    {
        FireWeapon();
    }

    //Fire the weapon
    private void FireWeapon()
    {
        if (Input.GetButtonDown(Tags.BUTTON_FIRE))
        {
            ProcessRayCastForHits();
            FireFX();
        }
    }

    //shoot the gun, and see what is hit
    private void ProcessRayCastForHits()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            PlayHitFX(hit);
            EnemyHealth target = hit.transform.gameObject.GetComponent<EnemyHealth>();
            if(target == null) { return; }
            target.DeductHealth(damage);
        }
        else
        {
            return;
        }
    }

    //play the fire effects when the weapon is fired
    private void FireFX()
    {
        fireGun.Play();
    }

    //play the effects of where the raycast hit
    private void PlayHitFX(RaycastHit hit)
    {
        Instantiate(hitParticles, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
