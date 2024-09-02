using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider essehealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    void Start()
    {
        health=maxHealth; 
    }

    void Update()
    {
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if(Input.GetKeyUp(KeyCode.Space)) { TakenDamage(10); }
        if(healthSlider.value != essehealthSlider.value)
        {
            essehealthSlider.value = Mathf.Lerp(essehealthSlider.value, health, lerpSpeed);
        }
    }
    public void TakenDamage(float damage)
    {
        health-= damage; 
    }
}
