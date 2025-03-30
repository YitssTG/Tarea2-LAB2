using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Life : MonoBehaviour
{
    public Image lifeBar;
    private float maxLife = 10f;
    private float currentLife;

    void Start()
    {
        currentLife = maxLife;
        UpdateLifeBar();
    }
    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            currentLife = 0;
            GameOver(); 
        }
        UpdateLifeBar();
    }
    private void UpdateLifeBar()
    {
        if (lifeBar != null)
        {
            lifeBar.fillAmount = currentLife / maxLife; 
        }
    }
    public float GetCurrentLife()
    {
        return currentLife;
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver"); 
    }
}
