using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDetection : MonoBehaviour
{
    public LoseTrigger loseTrigger;

    public float timer = 5f;

    public bool isFlipped = false;

    private void Update()
    {
        if (isFlipped)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                loseTrigger.ShowLose();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isFlipped = false;
        timer = 5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        isFlipped = true;
    }
}
