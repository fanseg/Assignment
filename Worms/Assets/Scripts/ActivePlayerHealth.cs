using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1f;
    }

    public void TakeDmg(float dmg) 
    {
        currentHealth -= dmg;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (healthBar.fillAmount <= 0.5f) 
        {
            healthBar.color = Color.yellow;
        }

        if (healthBar.fillAmount <= 0.25f) 
        {
            healthBar.color = Color.red;
        }

        if (currentHealth <= 0) 
        {
            GetComponent<ActivePlayer>().ResetCharacter();
            currentHealth = maxHealth;
            healthBar.fillAmount = 1f;
            healthBar.color = Color.green;
        }
    }
}
