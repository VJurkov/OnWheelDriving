using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public bool demoMode;

    public HealthBar healthBar;
    public LoseTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (demoMode)
        {
            return;
        }
        currentHealth = maxHealth / 2;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (demoMode)
        {
            transform.Rotate(0, 20 * Time.deltaTime, 0);
            return;
        }
        // kad pokrenemo igru i svaki put kad udarimo po space na tipkovnici uzet ce 20 kao damage
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamge(1);
        }
    }

    public void TakeDamge(float damage)
    {
        Debug.Log(damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;
            trigger.ShowLose();
        }
    }

    public void GiveMore(float battery)
    {
        currentHealth += battery;
        healthBar.SetHealth(currentHealth);
    }
}
