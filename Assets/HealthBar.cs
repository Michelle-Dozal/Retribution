using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{   
    public Slider healthBar;
    public health playerHealth;
    public Gradient gradient;
    public Image HealthBarImage;

    // Start is called before the first frame update
    private void Start()
    {   
        playerHealth = GameObject.FindGameObjectWithTag("mithra").GetComponent<health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;

        HealthBarImage.color = gradient.Evaluate(1f);
    }

   public void SetHealth(int hp){
        healthBar.value = hp;
        HealthBarImage.color = gradient.Evaluate(healthBar.normalizedValue);
   }
}
