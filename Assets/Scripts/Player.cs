using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // kad pokrenemo igru i svaki put kad udarimo po space na tipkovnici uzet ce 20 kao damage
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamge(1);
        }
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void GiveMore(int battery)
    {
        currentHealth += battery;
        healthBar.SetHealth(currentHealth);
    }
}
