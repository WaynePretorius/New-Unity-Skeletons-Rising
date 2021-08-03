using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health Settings")]
    [SerializeField] private float playerHealth = 100f;

    private float displayTimer = 1f;

    //cached references
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject onHitEffects;

    private void Start()
    {
        onHitEffects.SetActive(false);
    }

    //method runs every frame
    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }

    //method to damage the player
    public void DamagePlayer(float damage)
    {
        playerHealth -= damage;
        StartCoroutine(OnHit());

        if (playerHealth <= Mathf.Epsilon)
        {
            GetComponent<DeathHandler>().DeathScreen();
        }
    }
    
    //displays the onhit effects for 1 second
    private IEnumerator OnHit()
    {
        onHitEffects.SetActive(true);
        yield return new WaitForSeconds(displayTimer);
        onHitEffects.SetActive(false);
    }
}


