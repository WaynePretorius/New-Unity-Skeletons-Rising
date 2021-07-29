using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    //variables declared at teh start
    [Header("Zoom References")]
    private float zoomDistance = 40f;
    private float normalDistance = 60f;
    private float mouseX = 2f;
    private float mouseY = 2f;
    private float mouseZoomX = 1.5f;
    private float mouseZoomY = 1.5f;

    //cached references
    [Header("Required Components")]
    [SerializeField] private Camera fovCamera;
    [SerializeField] private RigidbodyFirstPersonController fpsController;

    //States of the class
    private bool isZooming = false;
    
    //functions for private variables
    public float ZoomDistance
    {
        get { return zoomDistance; }
        set { zoomDistance = value; }
    }
    public float MouseZoomX
    {
        get { return mouseZoomX; }
        set { mouseZoomX = value; }
    }
    public float MouseZoomY
    {
        get { return mouseZoomY; }
        set { mouseZoomY = value; }
    }
    public bool IsZooming
    {
        get { return isZooming; }
        set { isZooming = value; }
    }

    //first method called as the class is used
    private void Awake()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    //toggles the distance of the zoom function
    public void ZoomWeapon()
    {
        if (isZooming)
        {
            ScreenZoomed();
        }
        else
        {
            ScreenNormal();
        }
    }

    //values for the zoomed screen
    private void ScreenZoomed()
    {
        fovCamera.fieldOfView = zoomDistance;
        fpsController.mouseLook.XSensitivity = mouseZoomX;
        fpsController.mouseLook.YSensitivity = mouseZoomY;
    }

    //values for the screen when normal
    private void ScreenNormal()
    {
        fovCamera.fieldOfView = normalDistance;
        fpsController.mouseLook.XSensitivity = mouseX;
        fpsController.mouseLook.YSensitivity = mouseY;
    }
}
