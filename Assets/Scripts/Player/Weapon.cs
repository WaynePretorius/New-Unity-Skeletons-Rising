using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //variables for the weapon
    [Header("Weapon Settings")]
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private float zoomDistance = 50f;
    [SerializeField] private float zoomMouseY = 1f;
    [SerializeField] private float zoomMouseX = 1f;
    [SerializeField] private float timebetweenShots = 1f;

    //referenced caches
    [SerializeField] private Camera FPSCamera;
    [SerializeField] private ParticleSystem fireGun;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private Transform fxParent;
    [SerializeField] private AmmoType ammoType;
    
    private WeaponZoom zoom;
    private Ammo ammoSlot;

    //states of the game
    private bool canShoot = true;

    //method that is called everytime the object is enabled
    private void OnEnable()
    {
        zoom = GetComponentInParent<WeaponZoom>();
        ammoSlot = GetComponentInParent<Ammo>();
        EnableSettings();
    }

    //method that changes the zoom settings for the weapon
    private void EnableSettings()
    {
        canShoot = true;
        ZoomSettingsOnEnable();
    }

    //all options for zooming when the weapon is enabled
    private void ZoomSettingsOnEnable()
    {
        zoom.ZoomDistance = zoomDistance;
        zoom.MouseZoomX = zoomMouseX;
        zoom.MouseZoomY = zoomMouseY;
        if (zoom.IsZooming)
        {
            zoom.IsZooming = false;
            zoom.ZoomWeapon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
        ZoomWeapon();
    }

    //Fire the weapon
    private void FireWeapon()
    {
        if (Input.GetButton(Tags.BUTTON_FIRE) && ammoSlot.GetAmmoAmount(ammoType) >= 0)
        {
            if (canShoot)
            {
                StartCoroutine(TimeToShoot());
            }
        }
    }

    private IEnumerator TimeToShoot()
    {
        ProcessRayCastForHits();
        FireFX();
        ammoSlot.ReduceAmmo(ammoType);
        canShoot = false;
        yield return new WaitForSeconds(timebetweenShots);
        canShoot = true;
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
       GameObject vfx = Instantiate(hitParticles, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(vfx, .5f);
    }

    //Method that detects if the camera should zoom
    private void ZoomWeapon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoom.IsZooming = !zoom.IsZooming;
            zoom.ZoomWeapon();
        }
    }
}
