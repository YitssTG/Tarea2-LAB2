using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Life : MonoBehaviour
{ 
    public float maxLife = 10f;
    private float currentLife;
    public CronometroControll cronometro;

    public static event Action<float, float> OnLifeChanged;
    public static event Action OnPlayerDead;
    void Start()
    {
        currentLife = maxLife;
        OnLifeChanged?.Invoke(currentLife, maxLife);
    }
    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            currentLife = 0;
            OnPlayerDead?.Invoke();  
        }
        OnLifeChanged?.Invoke(currentLife, maxLife);
    }
    public void Heal(float amount)
    {
        currentLife += amount;
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
        OnLifeChanged?.Invoke(currentLife, maxLife);
    }
}
