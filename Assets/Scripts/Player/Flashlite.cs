using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlite : MonoBehaviour
{
    //variables declared
    [Header("Flashlite Settings")]
    [SerializeField] private float batteryTimer = 15f;
    [SerializeField] private float flickerTimer = .2f;
    [SerializeField] private float timeToStopFlicker = .8f;
    [SerializeField] private float minRandomFlicker = 1f;
    [SerializeField] private float maxFlickerTimer = 3f;

    //cached references
    private Light light;

    //states Declared
    [SerializeField] private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFalshLite();
        }
        if(batteryTimer <= 0)
        {
            isOn = false;
        }
        FlashliteOn();
    }

    //toggles the flashlite on and off
    private void ToggleFalshLite()
    {
            isOn = !isOn;
    }

    //starts and stops the flashliteTimer;
    private void FlashliteOn()
    {
        if (isOn)
        {
            light.enabled = true;
            StartCoroutine(FlashliteTimer());
            if(batteryTimer <= 0.5f)
            {
                StartCoroutine(EndOfLifeFlicker());
            }
        }
        else
        {
            light.enabled = false;
            StopAllCoroutines();
        }
    }

    //counts the battery life down;
    private IEnumerator FlashliteTimer()
    {
        float currentTime = batteryTimer;
        float milliseconds = 0.1f;
        yield return new WaitForSeconds(milliseconds);
        currentTime -= milliseconds;
        batteryTimer = currentTime;
    }

    //flickers the light on and off
    private IEnumerator EndOfLifeFlicker()
    {
        light.enabled = false;
        yield return new WaitForSeconds(flickerTimer);
        light.enabled = true;
        yield return new WaitForSeconds(flickerTimer);
        light.enabled = false;
        yield return new WaitForSeconds(flickerTimer);
        light.enabled = true;
    }

    //adds time to the flashlite battery
    public void AddTime(float extraPower)
    {
        batteryTimer += extraPower;
    }
}
