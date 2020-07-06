using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public bool demoMode;

    public float topSpeed = 100; // km per hour
    private float currentSpeed = 0;
    private float scale = 0;

    public AudioSource engineNoise;

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
        engineNoise = this.GetComponent<AudioSource>();
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
      

        currentSpeed = transform.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;
        scale = currentSpeed / topSpeed;

        engineNoise.pitch = scale;
       // engineNoise.volume = scale;
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
